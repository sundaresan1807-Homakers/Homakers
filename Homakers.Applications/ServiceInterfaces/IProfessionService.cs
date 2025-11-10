using Homakers.Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.ServiceInterfaces
{
    public interface IProfessionService
    {
        public Task<List<ProfessionsDto>> GetProfessionsAsync();
        public Task<ProfessionsDto?> GetProfessionsByName(string professionName);
    }
}
