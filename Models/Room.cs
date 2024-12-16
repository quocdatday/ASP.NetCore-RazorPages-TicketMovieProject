using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("Room")]
    public class Room : ModelBase
    {
        [Key]
         public int ROO_ID { get; set; }
        public string? Name { get; set; }
        public int CIN_ID { get; set; }
        [ForeignKey("CIN_ID")]
        public Cinema? Cinema { get; set; }
        public ICollection<Seat>? Seats { get; set; }
    }
}