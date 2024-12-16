using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("Movie")]
    public class Movie : ModelBase
    {
        [Key]
        public int MOV_ID { get; set; }
        public int CAT_ID { get; set; }
        public string? Name { get; set; }
        public string? Gender  { get; set; }
        public int Duration { get; set; }
        public DateTime PublichDate { get; set; }
        public DateTime StopPublichDate { get; set; }
        [ForeignKey("CAT_ID")]
        public Category? Category { get; set; }
        public MovieDetail? MovieDetail { get; set; }
        public ICollection<Screen>? Screens { get; set; }
        public ICollection<Review>? Reviews { get; set; }

    }
}