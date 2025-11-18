using Homakers.SQLite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.SQLite
{
    public class ProfessionalSQLiteServices
    {
        private readonly SQLiteAsyncConnection _database;

        public ProfessionalSQLiteServices(string dbPath)
        {

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SProfessionals>().Wait();
        }

        public async Task<SProfessionals> GetCurrentProfessionalAsync()
        {
            SProfessionals professional = await _database.Table<SProfessionals>().FirstOrDefaultAsync();
            return await _database.Table<SProfessionals>().FirstOrDefaultAsync();
        }

        public async Task<int> SavesProfessionalAsync(SProfessionals sprofessional)
        {
            SProfessionals professional = await GetCurrentProfessionalAsync();
            if (professional != null)
                return await _database.UpdateAsync(sprofessional);
            else
                return await _database.InsertAsync(sprofessional);
        }

        public Task<int> DeletesProfessionalAsync(SProfessionals sprofessional)
        {
            return _database.DeleteAsync(sprofessional);
        }
    }
}
