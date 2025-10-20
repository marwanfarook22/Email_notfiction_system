using Email_notfiction_system.Interfaces;
using Email_notfiction_system.Models;
using Email_notfiction_system.Third_Party_Services;

public class GmailClientAdaptor : IEmailService
{
    private readonly GmailClient _gmailClient;

    public GmailClientAdaptor(GmailClient gmailClient)
    {
        _gmailClient = gmailClient;
    }
    public EmailResult SendEmail(EmailMessage emailMessage)
    {
        var result = _gmailClient.SendEmail(emailMessage.Subject, emailMessage.Body);
        return new EmailResult
        {
            Success = result.Status == "sent",
            MessageId = result.Id ?? "",
            ErrorMessage = result.Status == "sent" ? null : "Failed to send email via Gmail"
        };

    }

    public bool ValidateConnection() => _gmailClient.ValidEmail(_gmailClient.ReceiverEmail);
}
