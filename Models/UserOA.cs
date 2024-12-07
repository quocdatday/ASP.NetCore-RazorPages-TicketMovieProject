using Microsoft.AspNetCore.Identity;

namespace ASPNetCoreRazorPage_TicketMovie.Models
{
    public class UserOA : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
