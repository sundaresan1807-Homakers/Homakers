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
    public class ProfessionalsRepository : IProfessionalsRepository
    {
        HomakerContext _dbContext;
        public ProfessionalsRepository(HomakerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Professionals>> GetProfessionalsAsync()
        {
            List<Professionals> professionalList = new List<Professionals>();
            try
            {
                professionalList = await _dbContext.Professionals.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return professionalList;
        }

        public async Task<Professionals?> GetProfessionalsByUsername(string username)
        {
            Professionals? professional = new Professionals();
            try
            {
                professional = await _dbContext.Professionals.Where(pro => pro.Username == username).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return professional;
        }
        public async Task<List<Professionals>> GetProfessionalsByName(string professionalName)
        {
            List<Professionals> professionalList = new List<Professionals>();
            try
            {
                professionalList = await _dbContext.Professionals.Where(pro => pro.Name.Contains(professionalName)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return professionalList;
        }
        public async Task<Professionals?> ValidateProfessional(string username, string password)
        {
            Professionals? professional = new Professionals();
            try
            {
                professional = await _dbContext.Professionals.Where(pro => pro.Username == username && pro.Password == password).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return professional;
        }
    }
}
