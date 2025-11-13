using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.DTOs
{
    public class ProfessionalProfession
    {
        public Guid ProfessionID { get; set; }
        public Guid ProfessionalsID { get; set; }
        public Guid CustomerID { get; set; }
        public string? ProfessionName { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Mobile { get; set; }
        public string? DistrictName { get; set; }
    }
}
