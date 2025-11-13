using Dapper;
using DbUp;
using Homakers.Domain.DataModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace Homakers.API.Data
{
    public class DatabaseInitializer
    {
        public static void EnsureDatabase(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = builder.InitialCatalog;
            builder.InitialCatalog = "master";
            var masterConnectionString = builder.ToString();

            using (var connection = new SqlConnection(masterConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
                        USE [master]
                        IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{databaseName}')
                        BEGIN
                            CREATE DATABASE {databaseName}
                        END";
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EnsureDatabaseAndSchema(string connectionString)
        {
           EnsureDatabase(connectionString);

            var scriptPath = Path.Combine(AppContext.BaseDirectory, "TableCreation");
            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem(scriptPath)
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();
            if (!result.Successful)
            {
                throw new Exception("Database migration failed", result.Error);
            }
        }

        public static void SeedDemoDataAsync(string connectionString)
        {
            var scriptPath = Path.Combine(AppContext.BaseDirectory, "DataInsertion");
            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem(scriptPath)
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();
            if (!result.Successful)
            {
                throw new Exception("Database migration failed", result.Error);
            }
            using var connection = new SqlConnection(connectionString);
            var procParams = new Dictionary<string, object>() { };
            var ProfessionalsList = ExecuteStoredProc<Professionals>("SELECT * FROM PROFESSIONALS", procParams, "Query", connection);
            var objList = ExecuteStoredProc<Profession>("SELECT * FROM PROFESSION", procParams, "Query", connection);
            var districtList = ExecuteStoredProc<Districts>("SELECT * FROM DISTRICTS", procParams, "Query", connection);
            if (ProfessionalsList.Count == 0)
            {
                if (objList?.Count > 0)
                {
                    for (int i = 0; i < objList.Count; i++)
                    {
                        for (int j = 0; j < 35; j++)
                        {
                            string inserquery = @"Insert Into Professionals(Name, Email, Username, Password, Mobile, ProfessionID, DistrictID) VALUES('Professional_" + i + j + "','Professional_" + i + j + "@mail.com'"
                                + ",'Professional_" + i + "00" + j + "','pro@123','" + 14356789 + j + "','" + objList[i].ProfessionID + "','" + districtList[j].DistrictID + "');";
                            ExecuteStoredProc<Professionals>(inserquery, procParams, "Query", connection);
                        }

                    }
                }

            }


            //if (ProfessionalsList.Count == 0)
            //{
            //    if (districtList?.Count > 0)
            //    {
            //        for (int i = 0; i < ProfessionalsList.Count; i++)
            //        {

            //            string inserquery = @"UPDATE Professionals SET DistrictID='" + districtList[i].DistrictID + "' WHERE ProfessionalsID='" + ProfessionalsList[i].ProfessionalsID + "'";
            //            ExecuteStoredProc<Professionals>(inserquery, procParams, "Query", connection);

            //        }
            //    }

            //}
        }
        public static List<T> ExecuteStoredProc<T>(string storedProcName, Dictionary<string, object> procParams, string commandType, SqlConnection conn) where T : class
        {

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (DbCommand command = conn.CreateCommand())
                {
                    command.CommandText = storedProcName;
                    if (commandType == "Procedure")
                        command.CommandType = CommandType.StoredProcedure;
                    else
                        command.CommandType = CommandType.Text;

                    command.CommandTimeout = 180;

                    foreach (KeyValuePair<string, object> procParam in procParams)
                    {
                        DbParameter param = command.CreateParameter();
                        param.ParameterName = procParam.Key;
                        param.Value = procParam.Value;
                        command.Parameters.Add(param);
                    }

                    DbDataReader reader = command.ExecuteReader();

                    List<T> objList = new List<T>();
                    IEnumerable<PropertyInfo> props = typeof(T).GetRuntimeProperties();
                    Dictionary<string, DbColumn> colMapping = reader.GetColumnSchema()
                        .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                        .ToDictionary(key => key.ColumnName.ToLower());

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            T obj = Activator.CreateInstance<T>();
                            foreach (PropertyInfo prop in props)
                            {
                                object val =
                                    reader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                                prop.SetValue(obj, val == DBNull.Value ? null : val);
                            }
                            objList.Add(obj);
                        }
                    }
                    reader.Dispose();

                    return objList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

    }
}
