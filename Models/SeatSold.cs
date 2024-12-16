using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("SeatSold")]
    public class SeatSold : ModelBase
    {
        [Key]
        public int SEASO_ID { get; set; }
        public string? USER_ID { get; set; }
        public string? Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEend { get; set; }
        public int? Room { get; set; } 
        public string? Status { get; set; } 
        public string? SEA_ID { get; set; } 

        
    }
}