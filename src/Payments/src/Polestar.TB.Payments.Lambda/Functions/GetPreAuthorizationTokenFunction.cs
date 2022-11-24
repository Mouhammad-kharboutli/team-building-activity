using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Polestar.TB.Payments.Application.Services;
using System.Text.Json;
using Polestar.TB.Payments.Lambda.Models;

namespace Polestar.TB.Payments.Lambda.Functions;

public class GetPreAuthorizationTokenFunction
{
    private static readonly IServiceProvider _serviceProvider = Startup.BuildContainer().BuildServiceProvider();

    private readonly IStripeClient _stripeClient;

    public GetPreAuthorizationTokenFunction()
    {
        _stripeClient = _serviceProvider.GetService<IStripeClient>();
    }

    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest apigProxyEvent, ILambdaContext context)
    {
        var request = JsonSerializer.Deserialize<PreAuthTokenRequestModel>(apigProxyEvent.Body);

        var response =
            await _stripeClient.CreateCardToken(
                request.CardNumber, 
                request.ExpireMonth, 
                request.ExpireYear,
                request.Cvc);

        return new APIGatewayProxyResponse
        {
            Body = JsonSerializer.Serialize(new PreAuthTokenResponseModel
            {
                PreAuthorizationToken = response,
            }),
            StatusCode = 200,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }
}