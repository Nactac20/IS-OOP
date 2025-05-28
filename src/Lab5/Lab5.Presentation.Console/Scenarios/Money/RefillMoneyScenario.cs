using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.UsersFiles;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Money;

public class RefillMoneyScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly CurUserManager _curUserManager;

    public RefillMoneyScenario(IUserService userService, CurUserManager curUserManager)
    {
        _userService = userService;
        _curUserManager = curUserManager;
    }

    public string Name => "Refill Money";

    public void Run()
    {
        if (_curUserManager.User is null)
        {
            AnsiConsole.WriteLine("You must log in first.");
            return;
        }

        decimal amount = AnsiConsole.Ask<decimal>("Enter the amount to refill:");

        LogResult result = _userService.Refill(_curUserManager.User.Uname, amount);

        string message = result switch
        {
            LogResult.Success => "Money refilled successfully!",
            LogResult.Failure => "Failed to refill money.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Press any key to continue...");
    }
}