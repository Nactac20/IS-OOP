using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.Models.UsersFiles;

namespace Lab5.Application.UsersFiles;

public class CurUserManager : ICurUserService
{
    public User? User { get; set; }
}