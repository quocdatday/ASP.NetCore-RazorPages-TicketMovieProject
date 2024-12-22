using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNetCoreRazorPage_TicketMovie.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class TestModel : PageModel
    {
        private readonly GmailAPI _gmailService;
        public string? TransactionDetails { get; private set; }
        public TestModel(GmailAPI gmailService)
        {
            _gmailService = gmailService;
        }


        public async Task OnGetAsync()
        {
            await _gmailService.InitializeServiceAsync();
            var email = await _gmailService.GetLatestBankEmailAsync("support@timo.vn");

            if (email != null)
            {
                TransactionDetails = _gmailService.ExtractTransactionDetails(email);
            }
            else
            {
                TransactionDetails = "No emails found.";
            }
        }
    }
}
