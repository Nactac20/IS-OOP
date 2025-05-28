using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.Models.AccountsFiles;

namespace Lab5.Application.Contracts.AccountsFiles;

public interface ICurAccountService
{
    LogResult GetBalance();

    LogResult WithdrawMoney(decimal amount);

    LogResult RefillMoney(decimal amount);

    LogResult GetTransactionsLog();

    void SetCurrentAccount(Account account);
}