using Email_notfiction_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_notfiction_system.Interfaces;

public interface IEmailService
{
    EmailResult SendEmail(EmailMessage emailMessage);
    public bool ValidateConnection();
}


 