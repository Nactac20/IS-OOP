using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.TransactionsFiles;
using Lab5.Application.Models.TransactionsFiles;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectProvider;

    public TransactionRepository(IPostgresConnectionProvider connectProvider)
    {
        _connectProvider = connectProvider;
    }

    public IEnumerable<Transaction> GetTransactionsByAccount(string accountId)
    {
        const string sql =
            """
            select id_trans, id_uname, amount, ttype
            from transactions
            where id_uname = :accountId;
            """;

        NpgsqlConnection connection = _connectProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountId", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();
        var transactions = new List<Transaction>();

        while (reader.Read())
        {
            transactions.Add(new Transaction(
                IdTrans: reader.GetInt64(0),
                IdUname: reader.GetString(1),
                Amount: reader.GetDecimal(2),
                Ttype: reader.GetFieldValue<TransactionType>(3)));
        }

        return transactions;
    }

    public void SaveTransaction(Transaction transaction)
    {
        const string sql =
            """
            insert into transactions (id_uname, amount, ttype)
            values (:id_uname, :amount, CAST(:ttype as transaction_type));
            """;

        NpgsqlConnection connection = _connectProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id_uname", transaction.IdUname);
        command.AddParameter("amount", transaction.Amount);
        command.AddParameter("ttype", transaction.Ttype);

        command.ExecuteNonQuery();
    }
}