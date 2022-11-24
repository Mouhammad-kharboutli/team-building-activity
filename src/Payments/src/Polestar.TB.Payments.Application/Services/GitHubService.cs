using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Polestar.TB.Payments.Application.Interfaces;
using Polestar.TB.Payments.Application.Options;
using Polestar.TB.Payments.Domain.Interfaces;
using Polestar.TB.Payments.Domain.Models;

namespace Polestar.TB.Payments.Application.Services;

public class GitHubService : IGitHubService
{
    private readonly FooOptions _options;
    private readonly IGitHubClient _client;

    public GitHubService(FooOptions options, IGitHubClient client)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<IEnumerable<GitHubIssue>> GetIssues(int count)
    {
        var res = await _client.GetAspNetDocsIssuesAsync();

        return res.Take(count);
    }

    public Task UpdateIssue(string id, string description)
    {
        return Task.CompletedTask;
    }
}