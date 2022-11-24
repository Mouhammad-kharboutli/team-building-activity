using Microsoft.Extensions.DependencyInjection;
using Polestar.TB.Payments.Application;
using Polestar.TB.Payments.Infrastructure;
using Polestar.TB.Payments.Application.Options;
using Polestar.Logging.Extensions;

namespace Polestar.TB.Payments.Lambda;

using Amazon.XRay.Recorder.Core;
using Amazon.XRay.Recorder.Handlers.AwsSdk;
using Polestar.Lambda;

public class Startup
{
    public static IServiceCollection BuildContainer()
    {
        return ConfigureServices();
    }

    private static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        var configuration = LambdaConfiguration.Get;
        services.AddSingleton(configuration);
        services.AddConfiguration(configuration.GetSection(nameof(FooOptions)), new FooOptions());

        services.AddPolestarLogging("Polestar.TB.Payments");
        services.AddApplication();
        services.AddInfrastructure();

        AWSSDKHandler.RegisterXRayForAllServices();
        return services;
    }
}