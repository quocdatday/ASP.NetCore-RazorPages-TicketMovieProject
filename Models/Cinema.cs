using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("Cinema")]
    public class Cinema : ModelBase
    {
        [Key]
        public int? CIN_ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; } 
        public string? Phone { get; set; } 
        public ICollection<Screen>? Screens { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
 }