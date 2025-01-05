using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class CategoryModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<Category>? Categories { get; set; }
        [BindProperty]
        public Category? Category { get; set; }
        [BindProperty]
        public int ID { get; set; }
        public CategoryModel(AppDataContext context)
        {
            _context = context;
            Categories = new List<Category>();
        }
        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.AsNoTracking().ToListAsync();
        }
        /// <summary>
        /// Add
        /// </summary>
        public async Task<IActionResult> OnPostAddAsync()
        {
            var cat = new Category
            {
                Type = Category!.Type,
                Age = Category.Age,
                CreatedDate = DateTime.Now,
            };
            await _context.Categories.AddAsync(cat);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
        /// <summary>
        ///     Edit 
        /// </summary>
        public async Task<IActionResult> OnPostEditAsync()
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CAT_ID == Category!.CAT_ID);
            if (category != null)
            {
                category.Type = Category!.Type;
                category.Age = Category.Age;
                category.UpdatedDate = DateTime.Now;
                _context.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            return BadRequest();
        }
        /// <summary>
        ///     Delete
        /// </summary>
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            Category = await _context.Categories.FirstOrDefaultAsync(x => x.CAT_ID == ID);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            return NotFound();
        }
    }
}
