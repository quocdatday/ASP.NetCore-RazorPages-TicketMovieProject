using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASPNetCoreRazorPage_TicketMovie.Models
 {
    [Table("Category")]
    public class Category : ModelBase
    {
        [Key]
        public int CAT_ID { get; set; }
        public string? Type  { get; set; }
        public int Age { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
 }