using Lab5.Application.Contracts.UsersFiles;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Account;

public class AccountLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;

    public AccountLoginScenarioProvider(IUserService userService)
    {
        _userService = userService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new AccountLoginScenario(_userService);
        return true;
    }
}