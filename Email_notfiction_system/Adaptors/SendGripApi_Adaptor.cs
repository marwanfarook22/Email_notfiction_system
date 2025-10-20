using Email_notfiction_system.Interfaces;
using Email_notfiction_system.Models;
using Email_notfiction_system.Third_Party_Services;

namespace Email_notfiction_system.Adaptors;

public class SendGripApi_Adaptor : IEmailService
{
    private readonly SendGripApiClient _sendGripApi;

    public SendGripApi_Adaptor(SendGripApiClient sendGripApi)
    {
        _sendGripApi = sendGripApi;
    }


    public bool ValidateConnection()
    {
        return _sendGripApi.CheckApiKey();
    }

    public EmailResult SendEmail(EmailMessage emailMessage)
    {
        var response = _sendGripApi.Send(emailMessage.From, emailMessage.To,
            emailMessage.Subject, emailMessage.Body);

        return new EmailResult
        {
            Success = response.StatusCode == 202,
            MessageId = response.MessageId,
            ErrorMessage = response.StatusCode != 202 ? "Failed to send" : null
        };




    }


}