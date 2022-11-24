using System.Threading.Tasks;

namespace Polestar.TB.Payments.Application.Services;

public interface IStripeClient
{
    Task<string> CreateCardToken(string number, string expMonth, string expYear, string cvc);
    Task<string> CollectPayment(string token, decimal amount);
}