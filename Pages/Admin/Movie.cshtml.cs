using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class MovieModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<Movie>? Movies { get; set; }
        public MovieModel(AppDataContext context)
        {
            _context = context;
            Movies = new List<Movie>();
        }
        public async Task OnGetAsync()
        {
            Movies = await _context.Movies.Include(x => x.Category).AsNoTracking().ToListAsync();
        }
    }
}
