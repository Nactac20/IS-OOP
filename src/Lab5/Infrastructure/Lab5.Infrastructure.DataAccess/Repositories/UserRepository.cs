using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.UsersFiles;
using Lab5.Application.Models.UsersFiles;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectProvider;

    public UserRepository(IPostgresConnectionProvider connectProvider)
    {
        _connectProvider = connectProvider;
    }

    public User? FindUser(string username, string password)
    {
        const string sql =
            """
            select uname, password, role
            from users
            where uname = :username and password = :password;
            """;

        NpgsqlConnection connection = _connectProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);
        command.AddParameter("password", password);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new User(
            Uname: reader.GetString(0),
            Password: reader.GetString(1),
            Role: reader.GetFieldValue<UserRole>(2));
    }

    public User? AdminLogin(string password)
    {
        const string sql =
            """
            select uname, password, role
            from users
            where role = 'Admin'
            limit 1;
            """;
        NpgsqlConnection connection = _connectProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();
        using (var command = new NpgsqlCommand(sql, connection))
        {
            using NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                var admin = new User(
                    Uname: reader.GetString(0),
                    Password: reader.GetString(1),
                    Role: reader.GetFieldValue<UserRole>(2));

                return string.Equals(password, admin.Password, StringComparison.Ordinal)
                    ? admin
                    : null;
            }
        }

        var newAdmin = new User("admin", UserRole.Admin, password);

        return newAdmin;
    }
}