using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("MovieDetail")]
    public class MovieDetail : ModelBase
    {
        [Key]
        public int MOVDT_ID { get; set; }
        public int MOV_ID { get; set; }
        public string? Director  { get; set; }
        public string? Actor { get; set; } 
        public string? Description { get; set; } 
        public string? Type { get; set; } 
        public string? Language { get; set; }
        [ForeignKey("MOV_ID")]
        public Movie? Movie { get; set; }
    }
 }