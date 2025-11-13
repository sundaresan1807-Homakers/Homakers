using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.DTOs
{
    public class DistrictsDto
    {
        public Guid DistrictID { get; set; }
        public string DistrictName { get; set; }
        public Int32 IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
