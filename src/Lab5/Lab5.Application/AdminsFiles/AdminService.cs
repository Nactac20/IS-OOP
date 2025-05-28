using Lab5.Application.Abstractions.AccountsFiles;
using Lab5.Application.Abstractions.UsersFiles;
using Lab5.Application.Contracts.AdminsFiles;
using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.Models.AccountsFiles;
using Lab5.Application.Models.UsersFiles;
using Lab5.Application.UsersFiles;

namespace Lab5.Application.AdminsFiles;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICurUserService _curUserService;
    private readonly CurUserManager _curUserManager;
    private readonly IUserRepository _userRepository;

    public AdminService(IAccountRepository accountRepository, ICurUserService curUserService, CurUserManager curUserManager, IUserRepository userRepository)
    {
        _accountRepository = accountRepository;
        _curUserService = curUserService;
        _curUserManager = curUserManager;
        _userRepository = userRepository;
    }

    public IEnumerable<Account> GetAllAccounts()
    {
        if (_curUserService.User?.Role != UserRole.Admin)
        {
            throw new InvalidOperationException("Only admin can access this method.");
        }

        return _accountRepository.GetAllAccounts();
    }

    public LogResult DeleteAccount(string uname)
    {
        if (_curUserService.User?.Role != UserRole.Admin)
        {
            return new LogResult.Failure();
        }

        _accountRepository.DeleteAccount(uname);
        return new LogResult.Success();
    }

    public LogResult Login(string password)
    {
        User? user = _userRepository.AdminLogin(password);

        if (user is null)
        {
            return new LogResult.Failure();
        }

        _curUserManager.User = user;
        return new LogResult.Success();
    }
}