using Email_notfiction_system.Adaptors;
using Email_notfiction_system.Interfaces;
using Email_notfiction_system.Models;
using Email_notfiction_system.Third_Party_Services;

public class ThirdPartyServiceFactroy
{
    public IEmailService GetThirdPartyService(int selection, EmailMessage mail)
    {
        switch (selection)
        {
            case 1:
                return SmptSection(mail);
            case 2:
                return SendGripSection(mail);
            case 3:
                return GmailSection(mail);
            case 4:
                return MailGunSection(mail);
            default:
                throw new ArgumentException("Invalid selection for third-party email service.");
        }
    }



    private IEmailService MailGunSection(EmailMessage mail)
    {
        MailgunClient mailGunClient = new MailgunClient(mail.From, "key-123456");
        var mailGunAdaptor = new MailgunClient_Adaptor(mailGunClient);

        return mailGunAdaptor;




    }

    private IEmailService GmailSection(EmailMessage mail)
    {
        GmailClient gmailClient = new GmailClient(mail.To, mail.From);
        var gmailAdaptor = new GmailClientAdaptor(gmailClient);

        return gmailAdaptor;



    }

    private IEmailService SendGripSection(EmailMessage mail)
    {
        SendGripApiClient sendGridClient = new SendGripApiClient("SENDGRID_API_KEY");
        var sendGridAdaptor = new SendGripApi_Adaptor(sendGridClient);

        return sendGridAdaptor;

    }

    private IEmailService SmptSection(EmailMessage mail)
    {
        SmtpClient smtpClient = new SmtpClient(mail.From, 587, mail.To, "password");
        var smtpAdaptor = new SmtpClient_Adaptor(smtpClient);

        return smtpAdaptor;





    }

}
