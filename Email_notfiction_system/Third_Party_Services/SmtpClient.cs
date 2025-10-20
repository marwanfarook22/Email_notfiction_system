using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_notfiction_system.Third_Party_Services;

public class SmtpClient
{
    public string Host { get; set; } = "";
    public int Port { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";

    public SmtpClient(string host, int port, string username, string password)
    {
        Host = host;
        Port = port;
        Username = username;
        Password = password;
    }

    public bool Send(string from, string to, string subject, string body)
    {
        if (!TestSmtpConnection())
        {
            Console.WriteLine($"[SMTP] Connection failed!");
            return false;
        }

        Console.WriteLine($"[SMTP] Connecting to {Host}:{Port}");
        Console.WriteLine($"[SMTP] From: {from} To: {to}");
        Console.WriteLine($"[SMTP] Subject: {subject}");
        Console.WriteLine($"[SMTP] Email sent successfully!");
        return true;
    }

    public bool TestSmtpConnection()
    {
        return !string.IsNullOrEmpty(Host) && Port > 0;
    }
}
