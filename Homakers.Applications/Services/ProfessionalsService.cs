using AutoMapper;
using Homakers.Applications.DTOs;
using Homakers.Applications.RepoInterfaces;
using Homakers.Applications.Repositories.RepoInterfaces;
using Homakers.Applications.ServiceInterfaces;
using Homakers.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.Services
{
    public class ProfessionalsService : IProfessionalsService
    {
        private IProfessionalsRepository _professionalRepository;
        private IMapper _mapper;
        public ProfessionalsService(IProfessionalsRepository professionalRepository, IMapper mapper)
        {
            _professionalRepository = professionalRepository;
            _mapper = mapper;
        }

        public async Task<List<ProfessionalsDto>> GetProfessionalsAsync()
        {
            List<ProfessionalsDto> ProfessionalsDtoList = new List<ProfessionalsDto>();
            List<Professionals> customerList = new List<Professionals>();
            try
            {
                customerList = await _professionalRepository.GetProfessionalsAsync();
                ProfessionalsDtoList = _mapper.Map<List<ProfessionalsDto>>(customerList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ProfessionalsDtoList;
        }
        public async Task<ProfessionalsDto?> GetProfessionalsByUsername(string username)
        {
            ProfessionalsDto? ProfessionalsDto = new ProfessionalsDto();
            Professionals? customer = new Professionals();
            try
            {
                customer = await _professionalRepository.GetProfessionalsByUsername(username);
                ProfessionalsDto = _mapper.Map<ProfessionalsDto?>(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ProfessionalsDto;
        }
        public async Task<List<ProfessionalsDto>> GetProfessionalsByName(string professionalName)
        {
            List<ProfessionalsDto> ProfessionalsDtoList = new List<ProfessionalsDto>();
            List<Professionals> customerList = new List<Professionals>();
            try
            {
                customerList = await _professionalRepository.GetProfessionalsByName(professionalName);
                ProfessionalsDtoList = _mapper.Map<List<ProfessionalsDto>>(customerList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ProfessionalsDtoList;
        }
        public async Task<ProfessionalsDto?> ValidateProfessional(string username, string password)
        {
            ProfessionalsDto? ProfessionalsDto = new ProfessionalsDto();
            Professionals? customer = new Professionals();
            try
            {
                customer = await _professionalRepository.ValidateProfessional(username, password);
                ProfessionalsDto = _mapper.Map<ProfessionalsDto?>(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ProfessionalsDto;
        }
    }
}
