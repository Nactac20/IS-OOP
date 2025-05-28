using Lab5.Application.Models.UsersFiles;

namespace Lab5.Application.Abstractions.UsersFiles;

public interface IUserRepository
{
    User? FindUser(string username, string password);

    User? AdminLogin(string password);
}