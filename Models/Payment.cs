using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("Payment")]
    public class Payment : ModelBase
    {
        [Key]
        public int PAY_ID { get; set; }
        public string Code { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 6);
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Discount { get; set; }
        public int Total { get; set; }
        public ICollection<SeatSold>? SeatSolds { get; set; }
    }       
}