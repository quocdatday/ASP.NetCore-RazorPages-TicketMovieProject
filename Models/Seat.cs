using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("Seat")]
    public class Seat : ModelBase
    {
        [Key]
        public int SEA_ID { get; set; }
        public int ROO_ID { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }  
        public int Price { get; set; }
        [ForeignKey("ROO_ID")]
        public Room? Room { get; set; }

    }
}