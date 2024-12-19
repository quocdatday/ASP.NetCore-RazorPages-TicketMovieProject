using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
{
    [Table("Screen")]
    public class Screen : ModelBase
    {
        [Key]
        public int SCR_ID { get; set; }
        public int MOV_ID { get; set; }
        public int ROO_ID { get; set; }
        public string? Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; } 
        public DateTime? Date { get; set; }
        [ForeignKey("ROO_ID")]
        public Room? Room { get; set; }
        [ForeignKey("MOV_ID")]
        public Movie? Movie { get; set; }
    }
}