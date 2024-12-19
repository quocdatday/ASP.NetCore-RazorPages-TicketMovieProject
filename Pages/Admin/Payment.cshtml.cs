using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class PaymentModel : PageModel
    {
        private readonly AppDataContext _context;
        public IList<Payment> Payments { get; set; }
        public PaymentModel(AppDataContext context)
        {
            _context = context;
            Payments = new List<Payment>();
        }
        public async Task OnGetAsync()
        {
            Payments = await _context.Payments.Include(x => x.SeatSolds).AsNoTracking().ToListAsync();
        }
    }
}
