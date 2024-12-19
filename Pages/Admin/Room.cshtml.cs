using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class RoomModel : PageModel
    {
        private readonly AppDataContext _context;
        public  IList<Room> Rooms { get; set; }
        public RoomModel(AppDataContext context)
        {
            _context = context;
            Rooms = new List<Room>();
        }
        public async Task OnGetAsync()
        {
            Rooms =await _context.Rooms
                .Include(x => x.Cinema)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
