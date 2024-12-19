using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class ReviewModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<Review> Reviews { get; set; }
        public ReviewModel(AppDataContext context)
        {
            _context = context;
            Reviews = new List<Review>();
        }
        public async Task OnGetAsync()
        {
            Reviews = await _context.Reviews.Include(x => x.Movie).AsNoTracking().ToListAsync();
        }
    }
}
