using Lab5.Application.Contracts.UsersFiles;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Account;

public class AccountLoginScenario : IScenario
{
    private readonly IUserService _userService;

    public AccountLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Account Login";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username:");
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your password:")
                .Secret());

        LogResult result = _userService.Login(username, password);

        string message = result switch
        {
            LogResult.Success => "Logged in successfully!",
            LogResult.Failure => "Failed to login.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Press any key to continue...");
    }
}