using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    public class MovieDetailModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<MovieDetail> MoveDetails { get; set; }
        public MovieDetailModel(AppDataContext context)
        {
            _context = context;
            MoveDetails = new List<MovieDetail>();
        }
        public async Task OnGetAsync()
        {
            MoveDetails = await _context.MovieDetails.AsNoTracking().ToListAsync();
        }
    }
}
