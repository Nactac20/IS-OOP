using Lab5.Application.AdminsFiles;
using Lab5.Application.Contracts.AdminsFiles;
using Lab5.Application.Contracts.UsersFiles;
using Lab5.Application.UsersFiles;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<CurUserManager>();
        collection.AddScoped<ICurUserService>(
            p => p.GetRequiredService<CurUserManager>());

        return collection;
    }
}