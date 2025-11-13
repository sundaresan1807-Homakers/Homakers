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
        public Task<List<ProfessionalsDto>> GetProfessionalsSummary(
             int pageNumber = 1
             , int pageSize = 20
             , string? districtName = null
             , string? professionName = null
             , string? professionalName = null);
        public Task<List<ProfessionalsDto>> GetProfessionalsAsync();
        public Task<ProfessionalsDto?> GetProfessionalsByUsername(string username);
        public Task<List<ProfessionalsDto>> GetProfessionalsByName(string professionalName);
        public Task<ProfessionalsDto?> ValidateProfessional(string username, string password);
        public Task<List<ProfessionalsDto>> GetProfessionalsByProfessionID(string professionID);
        public Task<ProfessionalsDto> GetProfessionalsByProfessionalID(string professionalID);
    }
}
