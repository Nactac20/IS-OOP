using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.AccountsFiles;
using Lab5.Application.Models.AccountsFiles;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectProvider;

    public AccountRepository(IPostgresConnectionProvider connectProvider)
    {
        _connectProvider = connectProvider;
    }

    public Account? FindAccount(string uname)
    {
        const string sql =
            """
            select uname, password
            from accounts
            where uname = :uname;
            """;

        NpgsqlConnection connection = _connectProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("uname", uname);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Account(
            Uname: reader.GetString(0),
            Password: reader.GetString(1));
    }

    public void SaveAccount(Account account)
    {
        const string sql =
            """
            insert into accounts (uname, password)
            values (:uname, :password);
            """;

        NpgsqlConnection connection = _connectProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("uname", account.Uname);
        command.AddParameter("password", account.Password);

        command.ExecuteNonQuery();
    }

    public IEnumerable<Account> GetAllAccounts()
    {
        const string sql =
            """
            select uname, password
            from accounts;
            """;

        NpgsqlConnection connection = _connectProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = command.ExecuteReader();
        var accounts = new List<Account>();

        while (reader.Read())
        {
            accounts.Add(new Account(
                Uname: reader.GetString(0),
                Password: reader.GetString(1)));
        }

        return accounts;
    }

    public void DeleteAccount(string uname)
    {
        const string sql =
            """
            delete from accounts
            where uname = :uname;
            """;

        NpgsqlConnection connection = _connectProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("uname", uname);

        command.ExecuteNonQuery();
    }
}