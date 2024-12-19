using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class ScreenModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<Screen> Screens { get; set; }
        public ScreenModel(AppDataContext context)
        {
            _context = context;
            Screens = new List<Screen>();
        }
        public async Task OnGetAsync()
        {
            Screens = await _context.Screens
                .Include(x => x.Movie)
                .Include(x => x.Room).ThenInclude(x => x!.Cinema)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
