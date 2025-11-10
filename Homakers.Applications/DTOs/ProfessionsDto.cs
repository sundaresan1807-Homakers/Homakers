using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.DTOs
{
    public class ProfessionsDto
    {
        public Guid ProfessionID { get; set; }
        public string? ProfessionName { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
