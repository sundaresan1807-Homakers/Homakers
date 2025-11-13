using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.DTOs
{
    public class ProfessionalsDto
    {
        public Guid ProfessionalsID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int Mobile { get; set; }
        public Guid ProfessionID { get; set; }
        public Guid DistrictID { get; set; }
        public string? ProfessionName { get; set; }
        public string? DistrictName { get; set; }
    }
}
