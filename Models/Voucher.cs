using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("Voucher")]
    public class Voucher : ModelBase
    {
        [Key]
        public int VOU_ID { get; set; }
        public string? Name { get; set; }
        public int Percent { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}