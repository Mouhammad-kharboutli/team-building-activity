using System;
using System.Net.Http;

namespace Polestar.TB.Payments.Infrastructure.Clients;

public class StripeClient
{
    private HttpClient _httpClient { get; set; }

    public StripeClient(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("https://api.github.com/");
        _httpClient = httpClient;
    }
}