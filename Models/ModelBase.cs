namespace ASPNetCoreRazorPage_TicketMovie.Models
{
    public class ModelBase
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
