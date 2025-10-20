

namespace Email_notfiction_system.Third_Party_Services
{
    public class GmailClient
    {
        public string ReceiverEmail { get; set; } = "";
        public string SenderEmail { get; set; } = "";

        public GmailClient(string receiverEmail, string senderEmail)
        {
            ReceiverEmail = receiverEmail;
            SenderEmail = senderEmail;
        }


        public GmailResult SendEmail(string title, string description)
        {
            if (!ValidEmail(ReceiverEmail))
            {
                Console.WriteLine($"[Gmail API] Invalid receiver email: {ReceiverEmail}");
                return new GmailResult
                {
                    Id = $"G-{Guid.NewGuid().ToString().Substring(0, 8)}",
                    Status = "unsent"
                };
            }

            Console.WriteLine($"[Gmail API] Sending email from {SenderEmail} to {ReceiverEmail}");
            Console.WriteLine($"[Gmail API] Title: {title}");
            Console.WriteLine($"[Gmail API] Description: {description}");

            return new GmailResult
            {
                Id = $"G-{Guid.NewGuid().ToString().Substring(0, 8)}",
                Status = "sent"
            };
        }

        public bool ValidEmail(string Mail)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(Mail);
                return true;
            }
            catch
            {
                return false;
            }


        }




        public class GmailResult
        {
            public string? Id { get; set; }
            public string Status { get; set; } = "";

        }



    }
}
