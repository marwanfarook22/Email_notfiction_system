using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_notfiction_system.Third_Party_Services;

public class SendGripApiClient
{
    public string ApiKey { get; set; }

    public SendGripApiClient(string apiKey)
    {
        ApiKey = apiKey;
    }

    public SendGridResponse Send(string from, string to, string subject, string HtmlContent)
    {
        Console.WriteLine($"[SendGrid API] Sending email to {to}");
        Console.WriteLine($"[SendGrid API] Subject: {subject}");
        if (!CheckApiKey())
        {
            return new SendGridResponse
            {
                StatusCode = 404,
                MessageId = $"SG-{Guid.NewGuid().ToString().Substring(0, 8)}"
            };
        }
        return new SendGridResponse
        {
            StatusCode = 202,
            MessageId = $"SG-{Guid.NewGuid().ToString().Substring(0, 8)}"
        };
    }

    public bool CheckApiKey()
    {
        return !string.IsNullOrEmpty(ApiKey);
    }
}

public class SendGridResponse
{
    public int StatusCode { get; set; }
    public string MessageId { get; set; } = "";
}
