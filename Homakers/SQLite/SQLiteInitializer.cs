using Homakers.SQLite.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.SQLite
{
    public class SQLiteInitializer
    {
        private SQLiteAsyncConnection _dbSQLiteContext;
        public async Task InitAsync()
        {
            if (_dbSQLiteContext != null)
                return;

            // Get a local app data path (works on Android, iOS, Windows)
            var dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HomakersSQLite.db3");

            _dbSQLiteContext = new SQLiteAsyncConnection(dbPath);
            await _dbSQLiteContext.CreateTableAsync<SCustomers>();
        }

        public async Task<int> AddCustomerAsync(SCustomers sCustomers)
        {
            await InitAsync();
            var customer = sCustomers;
            var isExistCustomer = _dbSQLiteContext.Table<SCustomers>().Where(cus => cus.Username == sCustomers.Username).FirstOrDefaultAsync();
            if (isExistCustomer != null)
            {
                return 0;
            }
            return await _dbSQLiteContext.InsertAsync(customer);
        }

        public async Task<List<SCustomers>> GetCustomerAsync()
        {
            await InitAsync();
            return await _dbSQLiteContext.Table<SCustomers>().ToListAsync();
        }
    }
}
