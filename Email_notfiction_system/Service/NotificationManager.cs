using Email_notfiction_system.Interfaces;
using Email_notfiction_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_notfiction_system.Service;

public class NotificationManager
{


    private readonly IEmailService _emailService;

    public NotificationManager(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public EmailResult SendWelcomeMessage(string userEmail, string userName)
    {
        var subject = "Welcome to Notfiction!";
        var body = $"Hello {userName},\n\nThank you for joining Notfiction. We're excited to have you on board!\n\nBest regards,\nThe Notfiction Team";
        var emailMessage = new EmailMessage
        {
            To = userEmail,
            From = "MarwanFarouq",
            Subject = subject,
            Body = body
        };
        return _emailService.SendEmail(emailMessage);

    }

    public EmailResult PasswordReset(string userEmail, string resetToken)
    {
        var subject = "Notfiction Password Reset";
        var body = $"Hello,\n\nWe received a request to reset your password.\n\nYour password reset token is: {resetToken}. This token expires in 1 hour. Please click the link below to reset it:\n\n[Reset Password Link]\n\nIf you did not request a password reset, please ignore this email.\n\nBest regards,\nThe Notfiction Team";
        var emailMessage = new EmailMessage
        {
            To = userEmail,
            From = "security@myapp.com",
            Subject = subject,
            Body = body
        };
        return _emailService.SendEmail(emailMessage);
    }


    public EmailResult SendOrderConfirmation(string userEmail, string orderNumber, decimal amount)
    {
        var body = $"Hello,\n\nThank you for your order! Your order number is {orderNumber} and the total amount is ${amount}.\n\nWe appreciate your business!\n\nBest regards,\nThe Notfiction Team";
        var emailMessage = new EmailMessage
        {
            To = userEmail,
            From = "orders@myapp.com",
            Subject = $"Order Confirmation #{orderNumber}",
            Body = $"Thank you for your order! Order #{orderNumber} for ${amount} has been confirmed."

        };
        return _emailService.SendEmail(emailMessage);

    }
}
