using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.Models.AccountsFiles;

namespace Lab5.Application.Contracts.AdminsFiles;

public interface IAdminService
{
    IEnumerable<Account> GetAllAccounts();

    LogResult DeleteAccount(string uname);

    LogResult Login(string password);
}