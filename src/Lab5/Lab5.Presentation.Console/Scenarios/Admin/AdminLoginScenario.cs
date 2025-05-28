using Lab5.Application.Contracts.AdminsFiles;
using Lab5.Application.Contracts.UsersFiles;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admin;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin Login";

    public void Run()
    {
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your Admin Password:")
                .Secret());

        LogResult result = _adminService.Login(password);

        string message = result switch
        {
            LogResult.Success => "Login as admin successfully!",
            LogResult.Failure => "You are a sock.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Press any key to continue...");
    }
}