using Stripe;
using System.Threading.Tasks;

namespace Polestar.TB.Payments.Infrastructure.Clients;

public class StripeClient : Polestar.TB.Payments.Application.Services.IStripeClient
{
    private const string STRIPE_API_KEY = "sk_test_51M7f8ZGJhw6xlZJ3HrzRTlMN3zj2CJYTqeddDBuQN69AQLG5OBi7EpwWwT7JJBvRFtrHIm3A5iXsz33uLJteidWM00zKBu7Jgo";

    public StripeClient()
    {
    }

    public async Task<string> CreateCardToken(string number, string expMonth, string expYear, string cvc)
    {
        StripeConfiguration.ApiKey = STRIPE_API_KEY;

        var options = new TokenCreateOptions
        {
            Card = new TokenCardOptions
            {
                Number = number,
                ExpMonth = expMonth,
                ExpYear = expYear,
                Cvc = cvc,
            },
        };
        var service = new TokenService();
        var token = await service.CreateAsync(options);

        return token.Id;
    }
}