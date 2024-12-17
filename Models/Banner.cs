using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("Banner")]
    public class Banner : ModelBase
    {
        [Key]
        public int BAN_ID { get; set; }
        public string? Image { get; set; }
        public string? Name  { get; set; }
    }
 }