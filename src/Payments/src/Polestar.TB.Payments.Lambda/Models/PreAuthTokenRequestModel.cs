using System.Drawing;

namespace Polestar.TB.Payments.Lambda.Models;

public class PreAuthTokenRequestModel
{
    public PreAuthTokenRequestModel()
    {

    }

    public string Name { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }
    public string Email { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string CardNumber { get; set; }
    public string ExpireYear { get; set; }
    public string ExpireMonth { get; set; }
    public string Cvc { get; set; }
    public string Description { get; set; }
}