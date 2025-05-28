using Lab5.Application.Contracts.UsersFiles;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Create;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;

    public CreateAccountScenarioProvider(IUserService userService)
    {
        _userService = userService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new CreateAccountScenario(_userService);
        return true;
    }
}