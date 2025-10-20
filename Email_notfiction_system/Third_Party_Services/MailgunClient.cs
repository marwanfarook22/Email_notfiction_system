using Email_notfiction_system.Interfaces;
using Email_notfiction_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_notfiction_system.Third_Party_Services;

public class MailgunClient
{
    private string _domain;
    private string _apiKey;

    public MailgunClient(string domain, string apiKey)
    {
        _domain = domain;
        _apiKey = apiKey;
    }

    public MailgunResult SendMessage(MailgunMessage message)
    {
        Console.WriteLine($"[Mailgun API] Sending from domain {_domain}");
        Console.WriteLine($"[Mailgun API] To: {message.RecipientEmail}");
        Console.WriteLine($"[Mailgun API] Title: {message.Title}");

        if (!TestConnection())
        {
            return new MailgunResult
            {
                Id = null,
                Status = "error"
            };

        }
        return new MailgunResult
        {
            Id = $"MG-{Guid.NewGuid().ToString().Substring(0, 8)}",
            Status = "queued"
        };
    }

    public bool TestConnection()
    {
        return !string.IsNullOrEmpty(_domain) && !string.IsNullOrEmpty(_apiKey);
    }


}

public class MailgunResult
{
    public string? Id { get; set; }
    public string Status { get; set; } = "";

}

public class MailgunMessage
{
    public string SenderEmail { get; set; } = "";
    public string RecipientEmail { get; set; } = "";
    public string Title { get; set; } = "";
    public string TextContent { get; set; } = "";

}


