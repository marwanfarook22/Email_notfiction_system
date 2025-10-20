using Email_notfiction_system.Interfaces;
using Email_notfiction_system.Models;
using Email_notfiction_system.Service;

public class NotfictionMangerFactroy
{
    public void GetNotfictionManager(IEmailService service, int selection, EmailMessage mail)
    {
        switch (selection)
        {
            case 1:
                SendWelcomeEmail(service, mail);
                break;
            case 2:
                SendPasswordResetEmail(service, mail);
                break;
            case 3:
                SendOrderConfirmationEmail(service, mail);
                break;
            default:
                UserInterfaces.ShowMessage("Exiting the application.");
                break;
        }
    }

    private void SendOrderConfirmationEmail(IEmailService service, EmailMessage mail)
    {
        var notificationManager = new NotificationManager(service);
        notificationManager.SendOrderConfirmation(mail.To, "ORD12345", 99.99m);

    }

    private void SendPasswordResetEmail(IEmailService service, EmailMessage mail)
    {
        var notificationManager = new NotificationManager(service);
        notificationManager.PasswordReset(mail.To, "new-Password");

    }

    private void SendWelcomeEmail(IEmailService service, EmailMessage mail)
    {
        var notificationManager = new NotificationManager(service);
        notificationManager.SendWelcomeMessage(mail.To, "User Regestier");
    }
}
