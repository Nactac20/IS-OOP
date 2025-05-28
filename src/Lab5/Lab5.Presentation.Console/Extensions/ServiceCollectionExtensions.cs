using Lab5.Presentation.Console.Scenarios;
using Lab5.Presentation.Console.Scenarios.Account;
using Lab5.Presentation.Console.Scenarios.Admin;
using Lab5.Presentation.Console.Scenarios.Create;
using Lab5.Presentation.Console.Scenarios.Money;
using Lab5.Presentation.Console.Scenarios.Transaction;
using Lab5.Presentation.Console.Scenarios.User;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AccountLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DeleteAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetAllAccountsScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RefillMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetTransactionHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();

        return collection;
    }
}