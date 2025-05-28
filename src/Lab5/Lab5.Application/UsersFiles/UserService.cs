using Lab5.Application.Abstractions.AccountsFiles;
using Lab5.Application.Abstractions.TransactionsFiles;
using Lab5.Application.Abstractions.UsersFiles;
using Lab5.Application.Contracts.AccountsFiles;
using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.Models.AccountsFiles;
using Lab5.Application.Models.UsersFiles;

namespace Lab5.Application.UsersFiles;

public class UserService : IUserService
{
        private readonly IUserRepository _userRepository;
        private readonly CurUserManager _curUserManager;
        private readonly IAccountRepository _accountRepository;
        private readonly ICurAccountService _curAccountService;

        public UserService(
            IUserRepository userRepository,
            CurUserManager curUserManager,
            IAccountRepository accountRepository,
            ITransactionRepository transactionRepository,
            ICurAccountService curAccountService)
        {
            _userRepository = userRepository;
            _curUserManager = curUserManager;
            _accountRepository = accountRepository;
            _curAccountService = curAccountService;
        }

        public LogResult Login(string uname, string password)
        {
            User? user = _userRepository.FindUser(uname, password);

            if (user is null)
            {
                return new LogResult.Failure();
            }

            _curUserManager.User = user;
            return new LogResult.Success();
        }

        public LogResult CreateAccount(string uname, string password)
        {
            if (string.IsNullOrWhiteSpace(uname) || string.IsNullOrWhiteSpace(password))
            {
                return new LogResult.Failure();
            }

            if (_curUserManager.User is null)
            {
                return new LogResult.Failure();
            }

            Account? existingAccount = _accountRepository.FindAccount(uname);
            if (existingAccount is not null)
            {
                return new LogResult.Failure();
            }

            var newAccount = new Account(Uname: uname, Password: password);
            _accountRepository.SaveAccount(newAccount);

            return new LogResult.Success();
        }

        public LogResult GetBalance(string uname)
        {
            Account? account = _accountRepository.FindAccount(uname);
            if (account is null)
            {
                return new LogResult.Failure();
            }

            _curAccountService.SetCurrentAccount(account);
            return _curAccountService.GetBalance();
        }

        public LogResult Withdraw(string uname, decimal amount)
        {
            Account? account = _accountRepository.FindAccount(uname);
            if (account is null)
            {
                return new LogResult.Failure();
            }

            _curAccountService.SetCurrentAccount(account);
            return _curAccountService.WithdrawMoney(amount);
        }

        public LogResult Refill(string uname, decimal amount)
        {
            Account? account = _accountRepository.FindAccount(uname);
            if (account is null)
            {
                return new LogResult.Failure();
            }

            _curAccountService.SetCurrentAccount(account);
            return _curAccountService.RefillMoney(amount);
        }

        public LogResult GetTransactionHistory(string uname)
        {
            Account? account = _accountRepository.FindAccount(uname);
            if (account is null)
            {
                return new LogResult.Failure();
            }

            _curAccountService.SetCurrentAccount(account);
            return _curAccountService.GetTransactionsLog();
        }
}