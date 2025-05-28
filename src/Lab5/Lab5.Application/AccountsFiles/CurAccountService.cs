using Lab5.Application.Abstractions.AccountsFiles;
using Lab5.Application.Abstractions.TransactionsFiles;
using Lab5.Application.Contracts.AccountsFiles;
using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.Models.AccountsFiles;
using Lab5.Application.Models.TransactionsFiles;

namespace Lab5.Application.AccountsFiles;

public class CurAccountService : ICurAccountService
{
    private readonly ITransactionRepository _transactionRepository;
    private Account? _currentAccount;

    public CurAccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public void SetCurrentAccount(Account account)
    {
        _currentAccount = account;
    }

    public LogResult GetBalance()
    {
        if (_currentAccount is null)
        {
            return new LogResult.Failure();
        }

        IEnumerable<Transaction> transactions = _transactionRepository.GetTransactionsByAccount(_currentAccount.Uname);
        decimal balance = transactions.Sum(t => t.Ttype == TransactionType.Refill ? t.Amount : -t.Amount);

        return new LogResult.Success();
    }

    public LogResult WithdrawMoney(decimal amount)
    {
        if (_currentAccount is null)
        {
            return new LogResult.Failure();
        }

        IEnumerable<Transaction> transactions = _transactionRepository.GetTransactionsByAccount(_currentAccount.Uname);
        decimal balance = transactions.Sum(t => t.Ttype == TransactionType.Refill ? t.Amount : -t.Amount);

        if (balance < amount)
        {
            return new LogResult.Failure();
        }

        var transaction = new Transaction(
            IdTrans: 0,
            IdUname: _currentAccount.Uname,
            Amount: amount,
            Ttype: TransactionType.Withdrawal);

        _transactionRepository.SaveTransaction(transaction);
        return new LogResult.Success();
    }

    public LogResult RefillMoney(decimal amount)
    {
        if (_currentAccount is null)
        {
            return new LogResult.Failure();
        }

        var transaction = new Transaction(
            IdTrans: 0,
            IdUname: _currentAccount.Uname,
            Amount: amount,
            Ttype: TransactionType.Refill);

        _transactionRepository.SaveTransaction(transaction);
        return new LogResult.Success();
    }

    public LogResult GetTransactionsLog()
    {
        if (_currentAccount is null)
        {
            return new LogResult.Failure();
        }

        IEnumerable<Transaction> transactions = _transactionRepository.GetTransactionsByAccount(_currentAccount.Uname);
        return new LogResult.Success();
    }
}