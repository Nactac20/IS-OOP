using Lab5.Application.Models.AccountsFiles;

namespace Lab5.Application.Abstractions.AccountsFiles;

public interface IAccountRepository
{
    Account? FindAccount(string uname);

    void SaveAccount(Account account);

    IEnumerable<Account> GetAllAccounts();

    void DeleteAccount(string uname);
}