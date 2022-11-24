using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polestar.TB.Payments.Application.Services;
using Polestar.TB.Payments.Domain.Interfaces;

namespace Polestar.TB.Payments.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IGitHubService, GitHubService>();
            
        return services;
    }
        
    public static void AddConfiguration<TConfig>(this IServiceCollection services,
        IConfigurationSection section, TConfig config)
        where TConfig : class, new()
    {
        section.Bind(config);
        services.AddSingleton(config);
    }
}