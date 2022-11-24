using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Polestar.TB.Payments.Application.Interfaces;
using Polestar.TB.Payments.Domain.Models;

namespace Polestar.TB.Payments.Infrastructure.Clients;

public class GitHubClient : IGitHubClient
{
    private HttpClient _client { get; }

    public GitHubClient(HttpClient client)
    {
        client.BaseAddress = new Uri("https://api.github.com/");
        client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
        client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");

        _client = client;
    }

    public async Task<IEnumerable<GitHubIssue>> GetAspNetDocsIssuesAsync()
    {
        var response = await _client.GetAsync(
            "/repos/aspnet/AspNetCore.Docs/issues?state=open&sort=created&direction=desc");

        response.EnsureSuccessStatusCode();

        await using var responseStream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync
            <IEnumerable<GitHubIssue>>(responseStream);
    }
}