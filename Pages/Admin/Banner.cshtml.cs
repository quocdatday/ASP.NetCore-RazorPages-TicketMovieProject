using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class BannerModel : PageModel
    {
        private readonly AppDataContext _context;
        public Banner? Banner { get; set; }
        public IList<Banner>? Banners { get; set; }

        [BindProperty]
        public Banner Ban { get; set; }

        [BindProperty] 
        public Input? Images { get; set; }

        [BindProperty] 
        public int ID { get; set; }

        public BannerModel(AppDataContext context)
        {
            _context = context;
            Banners = new List<Banner>();
            Ban = new Banner();
        }

        public async Task OnGetAsync()
        {
            Banners = await _context.Banners.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (Images!.Image != null)
            {
                var filename = Path.GetFileName(Images.Image.FileName);
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/banners", filename);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    Images.Image.CopyTo(stream);
                }
                var banner = new Banner
                {
                    Name = Ban.Name,
                    Image = filename
                };
                await _context.Banners.AddAsync(banner);
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            Banner = await _context.Banners.FirstOrDefaultAsync(x => x.BAN_ID == ID);
            if(Banner != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/banners", Banner.Image!);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                _context.Banners.Remove(Banner);
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }    
            return NotFound();
        }
    }
}
