using Lab5.Application.Contracts.AdminsFiles;
using Lab5.Application.Contracts.UsersFiles;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admin;

public class DeleteAccountScenario : IScenario
{
    private readonly IAdminService _adminService;

    public DeleteAccountScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Delete Account";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter the username of the account to delete:");

        LogResult result = _adminService.DeleteAccount(username);
        string message = result switch
        {
            LogResult.Success => $"Account '{username}' deleted successfully!",
            LogResult.Failure => $"Failed to delete account '{username}'.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Press any key to continue...");
    }
}