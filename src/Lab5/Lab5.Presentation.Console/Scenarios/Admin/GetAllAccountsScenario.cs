using Lab5.Application.Contracts.AdminsFiles;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admin;

public class GetAllAccountsScenario : IScenario
{
    private readonly IAdminService _adminService;

    public GetAllAccountsScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "View All Accounts";

    [Obsolete("Obsolete")]
    public void Run()
    {
        IEnumerable<Application.Models.AccountsFiles.Account> result = _adminService.GetAllAccounts();
        IEnumerable<Application.Models.AccountsFiles.Account> enumerable = result as Application.Models.AccountsFiles.Account[] ?? result.ToArray();
        if (result == null || !enumerable.Any())
        {
            AnsiConsole.WriteLine("No accounts found.");
            return;
        }

        var table = new Table();
        table.AddColumn("Username");

        foreach (Application.Models.AccountsFiles.Account account in enumerable)
        {
            table.AddRow(account.Uname);
        }

        AnsiConsole.Render(table);
        AnsiConsole.Ask<string>("Press any key to continue...");
    }
}