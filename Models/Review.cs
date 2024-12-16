using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("Review")]
    public class Review : ModelBase
    {
        [Key]
        public int REV_ID { get; set; }
        public int MOV_ID { get; set; }
        public string? UserName { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        [ForeignKey("MOV_ID")]
        public Movie? Movie { get; set; }
    }
}