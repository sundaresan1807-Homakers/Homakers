using System.ComponentModel.DataAnnotations;

namespace Homakers.SQLite.Models
{
    public class SProfessions
    {
        [Key]
        public Guid ProfessionID { get; set; }
        public string? ProfessionName { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
