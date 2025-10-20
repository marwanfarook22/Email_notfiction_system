using Email_notfiction_system.Interfaces;
using Email_notfiction_system.Models;

UserInterActions userInterActions = new();
ThirdPartyServiceFactroy thirdParty_Service_Factroy = new ThirdPartyServiceFactroy();
NotfictionMangerFactroy notfictionManger_Factroy = new NotfictionMangerFactroy();


UserInterfaces.ShowMessage("╔════════════════════════════════════════╗");
UserInterfaces.ShowMessage("║     Email Notification System - Demo   ║");
UserInterfaces.ShowMessage("╚════════════════════════════════════════╝");

UserInterfaces.ThirdPartyServiceSelection();

var userSelection = userInterActions.GetUserInput_ThirdPartyOptions();
EmailMessage email = userInterActions.GetEmail();
UserInterfaces.DisplayMenu();
var Menuselection = userInterActions.GetUserInput_MainMenuOptions();

IEmailService service = thirdParty_Service_Factroy.GetThirdPartyService(userSelection, email);


if (service != null)
{
    EmailResult result = service.SendEmail(email);

    if (result.Success)
    {
        UserInterfaces.ShowMessage("Email sent successfully!");
        notfictionManger_Factroy.GetNotfictionManager(service, Menuselection, email);
    }
    else
    {
        UserInterfaces.ShowMessage($"Failed: {result.ErrorMessage}");
    }
}


UserInterfaces.ShowMessage("╔════════════════════════════════════════╗");
UserInterfaces.ShowMessage("║  Demo Complete!                        ║");
UserInterfaces.ShowMessage("╚════════════════════════════════════════╝");
UserInterfaces.ShowMessage("");
UserInterfaces.ShowMessage("Press any key to exit...");



Console.ReadKey();
