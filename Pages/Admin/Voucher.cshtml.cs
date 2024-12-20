using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class VoucherModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<Voucher> Vouchers { get; set; }
        public VoucherModel(AppDataContext context)
        {
            _context = context;
            Vouchers = new List<Voucher>();
        }
        public async Task OnGetAsync()
        {
            Vouchers = await _context.Vouchers.AsNoTracking().ToListAsync();
        }
    }
}
