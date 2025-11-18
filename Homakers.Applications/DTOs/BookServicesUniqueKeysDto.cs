using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.DTOs
{
    public class BookServicesUniqueKeysDto
    {
        public Guid CustomerID { get; set; }
        public Guid ProfessionID { get; set; }
        public Guid? ProfessionalsID { get; set; }
    }
}
