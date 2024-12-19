using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class SeatSoldModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<SeatSold> SeatSolds { get; set; }
        public SeatSoldModel(AppDataContext context)
        {
            _context = context;
            SeatSolds = new List<SeatSold>();
        }
        public async Task OnGetAsync()
        {
            SeatSolds = await _context.SeatSolds.Include(x => x.Seat).AsNoTracking().ToListAsync();
        }
    }
}
