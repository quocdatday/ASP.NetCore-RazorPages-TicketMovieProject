using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class SeatModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<Seat> Seats { get; set; }
        public SeatModel(AppDataContext context)
        {
            _context = context;
            Seats = new List<Seat>();
        }
        public async Task OnGetAsync()
        {
            Seats = await _context.Seats.Include(x => x.Room).AsNoTracking().ToListAsync();
        }
    }
}
