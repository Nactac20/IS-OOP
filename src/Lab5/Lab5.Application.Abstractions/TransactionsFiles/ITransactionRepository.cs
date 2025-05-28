using Lab5.Application.Models.TransactionsFiles;

namespace Lab5.Application.Abstractions.TransactionsFiles;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetTransactionsByAccount(string accountId);

    void SaveTransaction(Transaction transaction);
}