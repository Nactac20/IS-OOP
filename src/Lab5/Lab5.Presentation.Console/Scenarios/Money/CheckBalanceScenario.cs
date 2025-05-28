using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.UsersFiles;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Money;

public class CheckBalanceScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly CurUserManager _curUserManager;

    public CheckBalanceScenario(IUserService userService, CurUserManager curUserManager)
    {
        _userService = userService;
        _curUserManager = curUserManager;
    }

    public string Name => "Check Balance";

    public void Run()
    {
        if (_curUserManager.User is null)
        {
            AnsiConsole.WriteLine("You must log in first.");
            return;
        }

        LogResult result = _userService.GetBalance(_curUserManager.User.Uname);

        string message = result switch
        {
            LogResult.Success => "Balance checked successfully!",
            LogResult.Failure => "Failed to check balance.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Press any key to continue...");
    }
}