


using Email_notfiction_system.Models;
using Email_notfiction_system.Third_Party_Services;

var Email = new EmailMessage
{
    Body = "Hello There <y Name is marwan iam 21 age",
    From = "Marwan",
    To = "Moahmed Farook",
    Subject = "Welcome Message "

};


SendGripApi sendGripApi = new SendGripApi("");
SendGripApi_Adaptor emailService = new SendGripApi_Adaptor(sendGripApi);

Console.WriteLine(" Is it Valid apiKey " + emailService.IsvalidEmail());
var respnse = emailService.SendEmail(Email);

Console.WriteLine(" Email Sent SuccessFully : " + respnse.Success);
Console.WriteLine("Email Message Id : " + respnse.MessageId);
Console.WriteLine("Email Eroor Message " + respnse.ErrorMessage);

Console.ReadKey();