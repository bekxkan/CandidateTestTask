using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Sigma.Services.Users;

namespace Sigma.Services;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        services.AddScoped<IUserService, UserService>();
    }
}
