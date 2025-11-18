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
    public class ProfessionRepository : IProfessionRepository
    {
        HomakerContext _dbContext;
        public ProfessionRepository(HomakerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Profession>> GetProfessionsAsync()
        {
            List<Profession> professionList = new List<Profession>();
            try
            {
                professionList = await _dbContext.Profession.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return professionList;
        }
        public async Task<Profession?> GetProfessionByProfessionName(string professionName)
        {
            Profession? customer = new Profession();
            try
            {
                customer = await _dbContext.Profession.Where(pro => pro.ProfessionName == professionName).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return customer;
        }

        public async Task<Profession?> GetProfessionByProfessionID(Guid professionID)
        {
            Profession? profession = new Profession();
            try
            {
                profession = await _dbContext.Profession.Where(pro => pro.ProfessionID == professionID).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return profession;
        }
    }
}
