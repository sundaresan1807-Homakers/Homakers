using Homakers.Domain.DataModels;
using Homakers.SQLite.Models;
using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.SQLite
{
    public class CustomerSQLiteInitializer
    {
        private readonly SQLiteAsyncConnection _database;

        public CustomerSQLiteInitializer(string dbPath)
        {

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SCustomers>().Wait();
        }

        public async Task<SCustomers> GetCurrentCustomerAsync()
        {
            SCustomers customer = await _database.Table<SCustomers>().FirstOrDefaultAsync();
            return await _database.Table<SCustomers>().FirstOrDefaultAsync();
        }

        public async Task<int> SavesCustomerAsync(SCustomers sCustomer)
        {
            SCustomers customer = await GetCurrentCustomerAsync();
            if (customer != null)
                return await _database.UpdateAsync(sCustomer);
            else
                return await _database.InsertAsync(sCustomer);
        }

        public Task<int> DeletesCustomerAsync(SCustomers sCustomer)
        {
            return _database.DeleteAsync(sCustomer);
        }
    }
}
