using Microsoft.Extensions.DependencyInjection;
using Polestar.TB.Payments.Application.Interfaces;
using Polestar.TB.Payments.Infrastructure.Clients;

namespace Polestar.TB.Payments.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpClient<IGitHubClient, GitHubClient>();

        return services;
    }
}