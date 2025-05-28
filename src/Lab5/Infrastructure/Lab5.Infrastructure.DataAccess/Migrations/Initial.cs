using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    
    create table users
    (
        user_id bigint primary key generated always as identity,
        user_name text not null unique,
        user_password text not null,
        user_role user_role not null
    );

    create table accounts
    (
        account_id bigint primary key generated always as identity,
        user_id bigint not null references users(user_id) on delete cascade,
        account_balance numeric(100, 2) not null default 0,
        account_password text not null
    );

    create table transactions
    (
        transaction_id bigint primary key generated always as identity,
        account_id bigint not null references accounts(account_id) on delete cascade,
        transaction_amount numeric(100, 2) not null,
        transaction_type transaction_type not null,
        transaction_timestamp timestamp not null default current_timestamp
    );

    create type user_role as enum
    (
        'admin',
        'client'
    );

    create type transaction_type as enum
    (
        'withdrawal',
        'refill'
    );
    
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table transactions cascade;
    drop table accounts cascade;
    drop table users cascade;
    
    drop type transaction_type;
    drop type user_role;

    """;
}