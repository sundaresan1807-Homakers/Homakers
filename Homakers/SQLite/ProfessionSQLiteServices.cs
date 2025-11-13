using Homakers.SQLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.SQLite
{
    public class ProfessionSQLiteServices
    {
        //private SQLiteAsyncConnection _dbSQLiteContext;
        //public async Task InitAsync()
        //{
        //    if (_dbSQLiteContext != null)
        //        return;

        //    // Get a local app data path (works on Android, iOS, Windows)
        //    var dbPath = Path.Combine(
        //        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HomakersSQLite.db3");

        //    _dbSQLiteContext = new SQLiteAsyncConnection(dbPath);
        //    await _dbSQLiteContext.CreateTableAsync<SProfessions>();
        //}

        //public async Task<int> AddProfessionAsync(SProfessions sProfessions)
        //{
        //    await InitAsync();
        //    var profession = sProfessions;
        //    List<SProfessions> ProfessionList = await GetProfessionAsync();

        //    SProfessions isExistProfession = ProfessionList.Where(pro => pro.ProfessionID == sProfessions.ProfessionID).FirstOrDefault();
        //    if (isExistProfession != null)
        //    {
        //        return 0;
        //    }
        //    return await _dbSQLiteContext.InsertAsync(profession);
        //}

        //public async Task<List<SProfessions>> GetProfessionAsync()
        //{
        //    await InitAsync();
        //    return await _dbSQLiteContext.Table<SProfessions>().ToListAsync();
        //}

        //public async Task<int> DeleteProfessionAsync()
        //{
        //    await InitAsync();
        //    return await _dbSQLiteContext.DropTableAsync<SProfessions>();
        //}
    }
}
