using Homakers.Applications.RepoInterfaces;
using Homakers.Domain;
using Homakers.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Infrastructure.Repositories
{
    public class UtilitiesRepository : IUtilityRepository
    {
        private HomakerContext _dbContext;
        public UtilitiesRepository(HomakerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Districts>> GetDistrictsAsync()
        {
            List<Districts> districts = new List<Districts>();
            try
            {
                districts = await _dbContext.Districts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return districts;
        }
    }
}
