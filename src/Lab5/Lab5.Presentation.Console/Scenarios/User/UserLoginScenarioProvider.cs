using Lab5.Application.Contracts.UsersFiles;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.User;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;

    public UserLoginScenarioProvider(IUserService userService)
    {
        _userService = userService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new UserLoginScenario(_userService);
        return true;
    }
}