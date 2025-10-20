using Email_notfiction_system.Interfaces;
using Email_notfiction_system.Models;
using Email_notfiction_system.Third_Party_Services;

namespace Email_notfiction_system.Adaptors;

public class SmtpClient_Adaptor : IEmailService
{
    private readonly SmtpClient _smtpClient;
    public SmtpClient_Adaptor(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }
    public EmailResult SendEmail(EmailMessage emailMessage)
    {
        bool success = _smtpClient.Send(emailMessage.From, emailMessage.To, emailMessage.Subject, emailMessage.Body);
        return new EmailResult
        {
            Success = success,
            MessageId = success ? $"SMTP-{Guid.NewGuid().ToString().Substring(0, 8)}" : "",
            ErrorMessage = success ? null : "Failed to send email via SMTP."
        };


    }

    public bool ValidateConnection() => _smtpClient.TestSmtpConnection();
}
