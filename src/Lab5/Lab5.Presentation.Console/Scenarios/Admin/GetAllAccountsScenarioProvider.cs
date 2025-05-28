using Lab5.Application.Contracts.AdminsFiles;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Admin;

public class GetAllAccountsScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;

    public GetAllAccountsScenarioProvider(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new GetAllAccountsScenario(_adminService);
        return true;
    }
}