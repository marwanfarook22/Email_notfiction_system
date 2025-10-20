public static class UserInterfaces
{
    public static void DisplayMenu()
    {
        Console.WriteLine("What Kind Of Email You Want To Send.");
        Console.WriteLine("1. Send Welcome Email");
        Console.WriteLine("2. Send Password Reset Email");
        Console.WriteLine("3. Send Order Confirmation Email");
        Console.WriteLine("4. Exit");
        Console.Write("Please select an option (1-4): ");
    }

    public static void ThirdPartyServiceSelection()
    {
        Console.WriteLine("Select Third-Party Email Service:");
        Console.WriteLine("1. SMTP");
        Console.WriteLine("2. SendGrid");
        Console.WriteLine("3. Gmail ");
        Console.WriteLine("4. Mailgun");
        Console.Write("Please select an option (1-4): \n");
    }

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}