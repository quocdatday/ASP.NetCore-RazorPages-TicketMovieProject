using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class GmailAPI
{
    private readonly string[] Scopes = { GmailService.Scope.GmailReadonly };
    private readonly string ApplicationName = "Your Application Name";
    private GmailService _gmailService;

    public async Task InitializeServiceAsync()
    {
        using var stream = new FileStream("wwwroot/credentials/credential.json", FileMode.Open, FileAccess.Read);
        string tokenPath = "wwwroot/credentials/token.json";

        var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.FromStream(stream).Secrets,
            Scopes,
            "user",
            CancellationToken.None,
            new FileDataStore(tokenPath, true));

        _gmailService = new GmailService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
    }

    public async Task<Message> GetLatestBankEmailAsync(string bankEmail)
    {
        var request = _gmailService.Users.Messages.List("me");
        request.Q = $"from:{bankEmail}";
        var response = await request.ExecuteAsync();

        if (response.Messages == null || response.Messages.Count == 0)
            return null!;

        var latestMessageId = response.Messages.First().Id;
        return await _gmailService.Users.Messages.Get("me", latestMessageId).ExecuteAsync();
    }

    public string ExtractTransactionDetails(Message message)
    {
        if (message == null || message.Payload == null)
            throw new ArgumentNullException("Message or its Payload is null.");

        var bodyData = message.Payload.Body?.Data;
        if (string.IsNullOrEmpty(bodyData))
        {
            // Nếu Body.Data không có nội dung, thử lấy từ Parts
            var parts = message.Payload.Parts?.FirstOrDefault(p => p.MimeType == "text/html");
            bodyData = parts?.Body?.Data;

            if (string.IsNullOrEmpty(bodyData))
                throw new InvalidOperationException("No email content found in Body or Parts.");
        }

        try
        {
            var decodedBody = Encoding.UTF8.GetString(Convert.FromBase64String(bodyData.Replace('-', '+').Replace('_', '/')));
            return decodedBody;
        }
        catch (FormatException)
        {
            throw new FormatException("The email content is not in a valid Base64 format.");
        }
    }

}
