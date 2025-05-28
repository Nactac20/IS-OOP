using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Application.Models.TransactionsFiles;
using Lab5.Application.Models.UsersFiles;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Plagins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<UserRole>();
        builder.MapEnum<TransactionType>();
    }
}