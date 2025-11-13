using Homakers.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.RepoInterfaces
{
    public interface IProfessionalsRepository
    {
        public Task<List<Professionals>> GetProfessionalsAsync();
        public Task<Professionals?> GetProfessionalsByUsername(string username);
        public Task<List<Professionals>> GetProfessionalsByName(string customerName);
        public Task<Professionals?> ValidateProfessional(string username, string password);
        public Task<List<Professionals>> GetProfessionalsByProfessionID(string professionID);
        public Task<Professionals> GetProfessionalsByProfessionalID(Guid professionalID);
    }
}
