using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.UsersFiles;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Money;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly CurUserManager _curUserManager;

    public WithdrawMoneyScenario(IUserService userService, CurUserManager curUserManager)
    {
        _userService = userService;
        _curUserManager = curUserManager;
    }

    public string Name => "Withdraw Money";

    public void Run()
    {
        if (_curUserManager.User is null)
        {
            AnsiConsole.WriteLine("You must log in first.");
            return;
        }

        decimal amount = AnsiConsole.Ask<decimal>("Enter the amount to withdraw:");

        LogResult result = _userService.Withdraw(_curUserManager.User.Uname, amount);

        string message = result switch
        {
            LogResult.Success => "Money withdrawn successfully!",
            LogResult.Failure => "Failed to withdraw money.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Press any key to continue...");
    }
}