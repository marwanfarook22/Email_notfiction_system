using Email_notfiction_system.Interfaces;
using Email_notfiction_system.Models;
using Email_notfiction_system.Third_Party_Services;

namespace Email_notfiction_system.Adaptors;

public class MailgunClient_Adaptor : IEmailService
{
    private readonly MailgunClient _mailgunClient;

    public MailgunClient_Adaptor(MailgunClient mailgunClient)
    {
        _mailgunClient = mailgunClient;
    }

    public bool ValidateConnection()
    {
        return _mailgunClient.TestConnection();
    }

    public EmailResult SendEmail(EmailMessage emailMessage)
    {
        var mailgunMessage = new MailgunMessage
        {
            SenderEmail = emailMessage.From,
            RecipientEmail = emailMessage.To,
            Title = emailMessage.Subject,
            TextContent = emailMessage.Body
        };
        var result = _mailgunClient.SendMessage(mailgunMessage);

        return new EmailResult
        {
            Success = result.Status == "queued",
            MessageId = result.Id,
            ErrorMessage = result.Status != "queued" ? "Failed to queue email." : null

        };

    }
}