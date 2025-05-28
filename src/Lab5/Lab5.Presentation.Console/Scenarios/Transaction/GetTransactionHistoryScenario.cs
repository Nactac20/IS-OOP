using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.UsersFiles;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Transaction;

public class GetTransactionHistoryScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly CurUserManager _curUserManager;

    public GetTransactionHistoryScenario(IUserService userService, CurUserManager curUserManager)
    {
        _userService = userService;
        _curUserManager = curUserManager;
    }

    public string Name => "View Transaction History";

    public void Run()
    {
        if (_curUserManager.User is null)
        {
            AnsiConsole.WriteLine("You must log in first.");
            return;
        }

        LogResult result = _userService.GetTransactionHistory(_curUserManager.User.Uname);

        string message = result switch
        {
            LogResult.Success => "Transaction history retrieved successfully!",
            LogResult.Failure => "Failed to retrieve transaction history.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Press any key to continue...");
    }
}