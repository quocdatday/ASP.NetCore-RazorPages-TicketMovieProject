using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("SeatSold")]
    public class SeatSold : ModelBase
    {
        [Key]
        public int SEASO_ID { get; set; }
        public int? PAY_ID { get; set; }
        public string? USER_ID { get; set; }
        public int SEA_ID { get; set; }
        public string? Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string? Status { get; set; }
        [ForeignKey("SEA_ID")]
        public Seat? Seat { get; set; }
        [ForeignKey("PAY_ID")]
        public Payment? Payment { get; set; }
    }
}