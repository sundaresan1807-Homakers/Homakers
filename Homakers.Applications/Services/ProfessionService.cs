using AutoMapper;
using Homakers.Applications.DTOs;
using Homakers.Applications.RepoInterfaces;
using Homakers.Applications.ServiceInterfaces;
using Homakers.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.Services
{
    public class ProfessionService : IProfessionService
    {
        private IProfessionRepository _professionRepository;
        private IMapper _mapper;
        public ProfessionService(IProfessionRepository professionRepository, IMapper mapper)
        {
            _professionRepository = professionRepository;
            _mapper = mapper;
        }

        public async Task<List<ProfessionsDto>> GetProfessionsAsync()
        {
            List<ProfessionsDto> ProfessionsDtoList = new List<ProfessionsDto>();
            List<Profession> ProfessionsList = new List<Profession>();
            try
            {
                ProfessionsList = await _professionRepository.GetProfessionsAsync();
                ProfessionsDtoList = _mapper.Map<List<ProfessionsDto>>(ProfessionsList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ProfessionsDtoList;
        }
        public async Task<ProfessionsDto?> GetProfessionsByName(string professionName)
        {
            ProfessionsDto? ProfessionsDto = new ProfessionsDto();
            Profession? profession = new Profession();
            try
            {
                profession = await _professionRepository.GetProfessionByProfessionName(professionName);
                ProfessionsDto = _mapper.Map<ProfessionsDto?>(profession);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ProfessionsDto;
        }
    }
}
