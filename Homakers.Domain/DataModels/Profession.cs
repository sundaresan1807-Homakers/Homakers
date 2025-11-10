
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Domain.DataModels
{
    public class Profession
    {
        [Key]
        public Guid ProfessionID { get; set; }
        public  string? ProfessionName { get; set; }
        public  decimal MinPrice { get; set; }
        public  decimal MaxPrice { get; set; }
    }
}
