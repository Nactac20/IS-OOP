using Lab5.Application.Contracts.AdminsFiles;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Admin;

public class DeleteAccountScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;

    public DeleteAccountScenarioProvider(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new DeleteAccountScenario(_adminService);
        return true;
    }
}