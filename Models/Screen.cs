using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
{
    [Table("Screen")]
    public class Screen : ModelBase
    {
        [Key]
        public int SCR_ID { get; set; }
        public int CIN_ID { get; set; }
        public int MOV_ID { get; set; }
        public string? ScreenStart { get; set; }
        public string? ScreenEnd { get; set; } 
        public DateTime? Date { get; set; }
        [ForeignKey("CIN_ID")]
        public Cinema? Cinema { get; set; }
        [ForeignKey("MOV_ID")]
        public Movie? Movie { get; set; }
    }
}