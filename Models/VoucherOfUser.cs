using NuGet.DependencyResolver;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("VoucherOfUser")]
    public class VoucherOfUser : ModelBase
    {
        [Key]
        public int VOFU_ID { get; set; }
        public int VOU_ID { get; set; }
        public string? USE_ID { get; set; }
        [ForeignKey("VOU_ID")]
        public Voucher? Voucher { get; set; }
    }
}