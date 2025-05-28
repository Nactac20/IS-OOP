namespace Lab5.Application.Contracts.UsersFiles;

public interface IUserService
{
    LogResult Login(string uname, string password);

    LogResult CreateAccount(string uname, string password);

    LogResult GetBalance(string uname);

    LogResult Withdraw(string uname, decimal amount);

    LogResult Refill(string uname, decimal amount);

    LogResult GetTransactionHistory(string uname);
}
