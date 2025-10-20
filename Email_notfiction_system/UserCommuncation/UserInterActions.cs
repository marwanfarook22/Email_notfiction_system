using Email_notfiction_system.Models;

public class UserInterActions
{
    private int result;

    public int GetUserInput_ThirdPartyOptions()
    {
        while (ValidtionUserinput())
        {
            UserInterfaces.ShowMessage("Invalid selection\n");
            UserInterfaces.ThirdPartyServiceSelection();

        }
        return result;


    }

    public int GetUserInput_MainMenuOptions()
    {
        while (ValidtionUserinput())
        {
            UserInterfaces.ShowMessage("Invalid selection\n");
            UserInterfaces.DisplayMenu();

        }
        return result;
    }

    public EmailMessage GetEmail()
    {
        Console.Write("Enter Receiver Email: ");
        string to = Console.ReadLine() ?? "";
        Console.Write("Enter Sender Email: ");
        string from = Console.ReadLine() ?? "";
        Console.Write("Enter Subject: ");
        string subject = Console.ReadLine() ?? "";
        Console.Write("Enter Body: ");
        string body = Console.ReadLine() ?? "";
        return new EmailMessage
        {
            To = to,
            From = from,
            Subject = subject,
            Body = body
        };

    }


    public bool ValidtionUserinput()
    {
        string input = Console.ReadLine() ?? "";
        input = input.Trim();

        bool validNumber = int.TryParse(input, out result);

        if (!validNumber)
            return true;

        if (result < 1 || result > 4)
            return true;

        return false;
    }


}
