using Homakers.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.RepoInterfaces
{
    public interface IProfessionRepository
    {
        public Task<List<Profession>> GetProfessionsAsync();
        public Task<Profession?> GetProfessionByProfessionName(string professionName);
        public Task<Profession?> GetProfessionByProfessionID(Guid professionID);
    }
}
