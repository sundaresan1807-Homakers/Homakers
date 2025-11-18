using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Homakers.Domain.DataModels
{
    public class BookService
    {
        [Key]
        public Guid BookServiceID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid ProfessionID { get; set; }
        public Guid? ProfessionalsID { get; set; }
        public string? BookingStatus { get; set; }
        public DateTime? AcceptedDateTime { get; set; }
        public DateTime? RejectedDateTime { get; set; }
        public decimal Price { get; set; }
        public decimal SGST { get; set; }
        public decimal CGST { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}