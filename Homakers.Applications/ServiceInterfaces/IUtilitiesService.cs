using Homakers.Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.ServiceInterfaces
{
    public interface IUtilitiesService
    {
        public Task<List<DistrictsDto>> GetDistrictsAsync();
    }
}
