using Microsoft.Extensions.DependencyInjection;
using System;
using Polestar.TB.Payments.Application.Services;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using System.Threading.Tasks;
using Polestar.TB.Payments.Lambda.Models;
using System.Collections.Generic;
using System.Text.Json;
using Polestar.TB.Payments.Lambda.Models.BookingModel;

namespace Polestar.TB.Payments.Lambda.Functions;

public class CollectPaymentFunction
{
    private static readonly IServiceProvider _serviceProvider = Startup.BuildContainer().BuildServiceProvider();

    private readonly IStripeClient _stripeClient;

    public CollectPaymentFunction()
    {
        _stripeClient = _serviceProvider.GetService<IStripeClient>();
    }

    public async Task<APIGatewayProxyResponse> FunctionHandler(
        APIGatewayProxyRequest apigProxyEvent,
        ILambdaContext context)
    {
        var orderModel = JsonSerializer.Deserialize<OrderModel>(apigProxyEvent.Body);

        var response = await _stripeClient.CollectPayment(orderModel.Payment.TokenId, orderModel.Payment.Amount);

        orderModel.Payment.Status = response;

        return new APIGatewayProxyResponse
        {
            Body = JsonSerializer.Serialize(orderModel),
            StatusCode = 200,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }

}