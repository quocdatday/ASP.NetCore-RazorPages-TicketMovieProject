using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class BannerModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<Banner>? Banners { get; set; }
        public BannerModel(AppDataContext context)
        {
            _context = context;
            Banners = new List<Banner>();
        }
        public async Task OnGetAsync()
        {
            Banners = await _context.Banners.AsNoTracking().ToListAsync();
        }
    }
}
