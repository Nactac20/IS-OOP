using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.UsersFiles;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Money;

public class CheckBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly CurUserManager _curUserManager;

    public CheckBalanceScenarioProvider(IUserService userService, CurUserManager curUserManager)
    {
        _userService = userService;
        _curUserManager = curUserManager;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_curUserManager.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new CheckBalanceScenario(_userService, _curUserManager);
        return true;
    }
}