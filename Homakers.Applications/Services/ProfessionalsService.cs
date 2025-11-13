using AutoMapper;
using Homakers.Applications.DTOs;
using Homakers.Applications.RepoInterfaces;
using Homakers.Applications.Repositories.RepoInterfaces;
using Homakers.Applications.ServiceInterfaces;
using Homakers.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
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
        private IProfessionRepository _professionRepository;
        private IUtilityRepository _utilityRepository;
        private IMapper _mapper;
        public ProfessionalsService(IProfessionalsRepository professionalRepository, IProfessionRepository professionRepository, IUtilityRepository utilityRepository, IMapper mapper)
        {
            _professionalRepository = professionalRepository;
            _professionRepository = professionRepository;
            _utilityRepository = utilityRepository;
            _mapper = mapper;
        }

        public async Task<List<ProfessionalsDto>> GetProfessionalsSummary(
             int pageNumber = 1
             , int pageSize = 20
             , string? districtName = null
             , string? professionName = null
             , string? professionalName = null)
        {
            List<ProfessionalsDto> ProfessionalsDtoList = new List<ProfessionalsDto>();
            List<Professionals> professionalList = new List<Professionals>();
            List<Profession> professionList = new List<Profession>();
            List<Districts> districtsList = new List<Districts>();
            try
            {
                professionalList = await _professionalRepository.GetProfessionalsAsync();
                professionList = await _professionRepository.GetProfessionsAsync();
                districtsList = await _utilityRepository.GetDistrictsAsync();
                ProfessionalsDtoList = _mapper.Map<List<ProfessionalsDto>>(professionalList);
                ProfessionalsDtoList.ForEach(d =>
                {
                    d.ProfessionName = professionList.Where(p => p.ProfessionID == d.ProfessionID).FirstOrDefault().ProfessionName;
                    d.DistrictName = districtsList.Where(p => p.DistrictID == d.DistrictID).FirstOrDefault().DistrictName;
                });
                if (districtName != null && districtName != "")
                {
                    ProfessionalsDtoList = ProfessionalsDtoList.Where(pro => pro.DistrictName.Contains(districtName)).ToList();
                }
                if (professionName != null && professionName != "")
                {
                    ProfessionalsDtoList = ProfessionalsDtoList.Where(pro => pro.ProfessionName.Contains(professionName)).ToList();
                }
                if (professionalName != null)
                {
                    ProfessionalsDtoList = ProfessionalsDtoList.Where(pro => pro.Name.ToString().Contains(professionalName)).ToList();
                }
                ProfessionalsDtoList = ProfessionalsDtoList.OrderBy(pro => pro.Name)
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .ToList();
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

        public async Task<List<ProfessionalsDto>> GetProfessionalsByProfessionID(string professionID)
        {
            List<ProfessionalsDto> ProfessionalsDtoList = new List<ProfessionalsDto>();
            List<Professionals> professionList = new List<Professionals>();
            try
            {
                professionList = await _professionalRepository.GetProfessionalsByProfessionID(professionID);
                ProfessionalsDtoList = _mapper.Map<List<ProfessionalsDto>>(professionList);
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

        public async Task<ProfessionalsDto> GetProfessionalsByProfessionalID(string professionalID)
        {
            ProfessionalsDto ProfessionalsDto = new ProfessionalsDto();
            Professionals professionalList = new Professionals();
            List<Profession> professionList = new List<Profession>();
            List<Districts> districtsList = new List<Districts>();
            try
            {
                Guid Id = Guid.Parse(professionalID);
                professionalList = await _professionalRepository.GetProfessionalsByProfessionalID(Id);
                professionList = await _professionRepository.GetProfessionsAsync();
                districtsList = await _utilityRepository.GetDistrictsAsync();
                ProfessionalsDto = _mapper.Map<ProfessionalsDto>(professionalList);
                ProfessionalsDto.ProfessionName = professionList.Where(p => p.ProfessionID == ProfessionalsDto.ProfessionID).FirstOrDefault().ProfessionName;
                ProfessionalsDto.DistrictName = districtsList.Where(p => p.DistrictID == ProfessionalsDto.DistrictID).FirstOrDefault().DistrictName;
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
