using Lab5.Application.Contracts.UsersFiles;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Create;

public class CreateAccountScenario : IScenario
{
    private readonly IUserService _userService;

    public CreateAccountScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Create Account";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username:");
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your password:")
                .Secret());

        LogResult result = _userService.CreateAccount(username, password);

        string message = result switch
        {
            LogResult.Success => "Account created successfully!",
            LogResult.Failure => "Failed to create account.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Press any key to continue...");
    }
}