using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Polestar.TB.Payments.Domain.Interfaces;
using Polestar.TB.Payments.Domain.Models;
using Polestar.Contracts;
using Polestar.Lambda.Functions;
using Polestar.Policy;
using Polestar.TB.Payments.Lambda.Models.FromBoilerplate;

namespace Polestar.TB.Payments.Lambda.Functions.FromBoilerplate;

/// <summary>
/// Example Of a GraphQL query "backing" handler with a Data response.
/// </summary>
public class GQLGetGitHubIssuesFunction : GraphQLRequestResponseBaseFunction<GetIssuesRequest, IEnumerable<GitHubIssue>>
{
    private static readonly IServiceProvider _serviceProvider = Startup.BuildContainer().BuildServiceProvider();

    public GQLGetGitHubIssuesFunction(IServiceProvider serviceProvider = null, IPolicyHandler policyHandler = null)
        : base(serviceProvider ?? _serviceProvider, policyHandler)
    {
    }

    public GQLGetGitHubIssuesFunction()
        : base(_serviceProvider)
    {
    }

    protected override async Task<IEnumerable<GitHubIssue>> HandleFunctionAsync(Request<GetIssuesRequest> input)
    {
        var githubService = ServiceProvider.GetService<IGitHubService>();
        var issues = await githubService.GetIssues(input.Data.Count);

        return issues;
    }
}