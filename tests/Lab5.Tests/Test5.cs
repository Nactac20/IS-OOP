using Lab5.Application.Abstractions.AccountsFiles;
using Lab5.Application.Abstractions.TransactionsFiles;
using Lab5.Application.Abstractions.UsersFiles;
using Lab5.Application.AccountsFiles;
using Lab5.Application.AdminsFiles;
using Lab5.Application.Contracts.AccountsFiles;
using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.Models.AccountsFiles;
using Lab5.Application.Models.TransactionsFiles;
using Lab5.Application.Models.UsersFiles;
using Lab5.Application.UsersFiles;
using NSubstitute;
using Xunit;

namespace Lab5.Tests;

public class Test5
{
    [Fact]
    public void GetBalance_WithValidAccount_ReturnsSuccess()
    {
        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        var account = new Account("testUser", "password");

        var transactions = new List<Transaction>
        {
            new Transaction(1, "testUser", 100, TransactionType.Refill),
            new Transaction(2, "testUser", 50, TransactionType.Withdrawal),
        };

        transactionRepository.GetTransactionsByAccount("testUser").Returns(transactions);

        var accountService = new CurAccountService(Substitute.For<IAccountRepository>(), transactionRepository);
        accountService.SetCurrentAccount(account);

        Application.Contracts.UsersFiles.LogResult result = accountService.GetBalance();

        Assert.IsType<LogResult.Success>(result);
    }

    [Fact]
    public void GetBalance_WithNoAccount_ReturnsFailure()
    {
        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        var accountService = new CurAccountService(Substitute.For<IAccountRepository>(), transactionRepository);

        LogResult result = accountService.GetBalance();

        Assert.IsType<LogResult.Failure>(result);
    }

    [Fact]
    public void WithdrawMoney_WithSufficientBalance_ReturnsSuccess()
    {
        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        var account = new Account("testUser", "password");

        var transactions = new List<Transaction>
        {
            new Transaction(1, "testUser", 200, TransactionType.Refill),
        };

        transactionRepository.GetTransactionsByAccount("testUser").Returns(transactions);

        var accountService = new CurAccountService(Substitute.For<IAccountRepository>(), transactionRepository);
        accountService.SetCurrentAccount(account);

        LogResult result = accountService.WithdrawMoney(100);

        Assert.IsType<LogResult.Success>(result);
        transactionRepository.Received(1).SaveTransaction(Arg.Is<Transaction>(t => t.Amount == 100 && t.Ttype == TransactionType.Withdrawal));
    }

    [Fact]
    public void WithdrawMoney_WithInsufficientBalance_ReturnsFailure()
    {
        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        var account = new Account("testUser", "password");

        var transactions = new List<Transaction>
        {
            new Transaction(1, "testUser", 50, TransactionType.Refill),
        };

        transactionRepository.GetTransactionsByAccount("testUser").Returns(transactions);

        var accountService = new CurAccountService(Substitute.For<IAccountRepository>(), transactionRepository);
        accountService.SetCurrentAccount(account);

        LogResult result = accountService.WithdrawMoney(100);

        Assert.IsType<LogResult.Failure>(result);
        transactionRepository.DidNotReceive().SaveTransaction(Arg.Any<Transaction>());
    }

    [Fact]
    public void Login_WithValidCredentials_ReturnsSuccess()
    {
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        var user = new User("testUser", UserRole.Client, "password");
        userRepository.FindUser("testUser", "password").Returns(user);

        var userService = new UserService(
            userRepository,
            Substitute.For<CurUserManager>(),
            Substitute.For<IAccountRepository>(),
            Substitute.For<ITransactionRepository>(),
            Substitute.For<ICurAccountService>());

        LogResult result = userService.Login("testUser", "password");

        Assert.IsType<LogResult.Success>(result);
    }

    [Fact]
    public void Login_WithInvalidCredentials_ReturnsFailure()
    {
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        userRepository.FindUser("testUser", "wrongPassword").Returns((User?)null);

        var userService = new UserService(
            userRepository,
            Substitute.For<CurUserManager>(),
            Substitute.For<IAccountRepository>(),
            Substitute.For<ITransactionRepository>(),
            Substitute.For<ICurAccountService>());

        LogResult result = userService.Login("testUser", "wrongPassword");

        Assert.IsType<LogResult.Failure>(result);
    }

    [Fact]
    public void CreateAccount_WithExistingUsername_ReturnsFailure()
    {
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository.FindAccount("existingUser").Returns(new Account("existingUser", "password"));

        var userService = new UserService(
            Substitute.For<IUserRepository>(),
            Substitute.For<CurUserManager>(),
            accountRepository,
            Substitute.For<ITransactionRepository>(),
            Substitute.For<ICurAccountService>());

        LogResult result = userService.CreateAccount("existingUser", "password");

        Assert.IsType<LogResult.Failure>(result);
        accountRepository.DidNotReceive().SaveAccount(Arg.Any<Account>());
    }

    [Fact]
    public void DeleteAccount_WithAdminRole_ReturnsSuccess()
    {
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ICurUserService curUserService = Substitute.For<ICurUserService>();
        curUserService.User.Returns(new User("admin", UserRole.Admin, "password"));

        var adminService = new AdminService(
            accountRepository,
            curUserService,
            Substitute.For<CurUserManager>(),
            Substitute.For<IUserRepository>());

        LogResult result = adminService.DeleteAccount("testUser");

        Assert.IsType<LogResult.Success>(result);
        accountRepository.Received(1).DeleteAccount("testUser");
    }

    [Fact]
    public void DeleteAccount_WithNonAdminRole_ReturnsFailure()
    {
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ICurUserService curUserService = Substitute.For<ICurUserService>();
        curUserService.User.Returns(new User("user", UserRole.Client, "password"));

        var adminService = new AdminService(
            accountRepository,
            curUserService,
            Substitute.For<CurUserManager>(),
            Substitute.For<IUserRepository>());

        LogResult result = adminService.DeleteAccount("testUser");

        // Assert
        Assert.IsType<LogResult.Failure>(result);
        accountRepository.DidNotReceive().DeleteAccount(Arg.Any<string>());
    }
}