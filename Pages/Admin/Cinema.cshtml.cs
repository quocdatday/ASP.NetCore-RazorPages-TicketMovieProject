using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class CinemaModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<Cinema>? Cinemas { get; set; }
        public CinemaModel(AppDataContext context) { 
            _context = context;
            Cinemas = new List<Cinema>();
        }
        public async Task OnGetAsync()
        {
            Cinemas = await _context.Cinemas.AsNoTracking().ToListAsync();
        }
    }
}
