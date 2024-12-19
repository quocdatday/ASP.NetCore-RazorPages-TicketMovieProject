using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class CategoryModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<Category>? Categories { get; set; }
        public CategoryModel(AppDataContext context)
        {
            _context = context;
            Categories = new List<Category>();
        }
        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.AsNoTracking().ToListAsync();
        }
    }
}
