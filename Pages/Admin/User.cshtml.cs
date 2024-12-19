using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class UserModel : PageModel
    {
        private readonly SignInManager<UserOA> _signInManager;
        private readonly UserManager<UserOA> _userManager;
        private readonly IUserStore<UserOA> _userStore;
        //private readonly ILogger<UserOA> _logger;
        public IList<UserOA>? Users { get; set; } = [];
        public UserModel(
            UserManager<UserOA> userManager,
            IUserStore<UserOA> userStore,
            SignInManager<UserOA> signInManager,
            //ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            //_emailStore = GetEmailStore();
            _signInManager = signInManager;
            //_logger = logger;
        }
        public async Task OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
        }
    }
}
