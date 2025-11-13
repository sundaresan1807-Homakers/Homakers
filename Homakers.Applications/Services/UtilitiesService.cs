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
    public class UtilitiesService : IUtilitiesService
    {
        private IUtilityRepository _utilitiesRepository;
        private IMapper _mapper;
        public UtilitiesService(IUtilityRepository utilitiesRepository, IMapper mapper)
        {
            _utilitiesRepository = utilitiesRepository;
            _mapper = mapper;
        }

        public async Task<List<DistrictsDto>> GetDistrictsAsync()
        {
            List<DistrictsDto> districtDtoList = new List<DistrictsDto>();
            List<Districts> distrcitList = new List<Districts>();
            try
            {
                distrcitList = await _utilitiesRepository.GetDistrictsAsync();
                districtDtoList = _mapper.Map<List<DistrictsDto>>(distrcitList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return districtDtoList;
        }
    }
}
