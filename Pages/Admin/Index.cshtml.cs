using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<UserOA> _userManager;
        private readonly AppDataContext _context;

        public IndexModel(AppDataContext context, UserManager<UserOA> userManager) {
            _context = context;
            _userManager = userManager;
        }
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
        }
    }
}
