using Homakers.Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.ServiceInterfaces
{
    public interface IProfessionalsService
    {
        public  Task<List<ProfessionalsDto>> GetProfessionalsAsync();
        public  Task<ProfessionalsDto?> GetProfessionalsByUsername(string username);
        public  Task<List<ProfessionalsDto>> GetProfessionalsByName(string professionalName);
        public  Task<ProfessionalsDto?> ValidateProfessional(string username, string password);
    }
}
