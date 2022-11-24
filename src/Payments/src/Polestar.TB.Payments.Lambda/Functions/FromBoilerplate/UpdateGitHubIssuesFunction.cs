using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Polestar.TB.Payments.Domain.Interfaces;

namespace Polestar.TB.Payments.Lambda.Functions.FromBoilerplate;

using Polestar.Contracts;
using Polestar.Lambda.Functions;
using Polestar.Policy;
using Polestar.TB.Payments.Lambda.Models.FromBoilerplate;

/// <summary>
/// Example Of a GraphQL query "backing" handler without a Data response.
/// </summary>
public class UpdateGitHubIssuesFunction : GraphQLRequestBaseFunction<UpdateIssueRequest>
{
    private static readonly IServiceProvider _serviceProvider = Startup.BuildContainer().BuildServiceProvider();

    public UpdateGitHubIssuesFunction(IServiceProvider serviceProvider = null, IPolicyHandler policyHandler = null)
        : base(serviceProvider ?? _serviceProvider, policyHandler)
    {
    }

    public UpdateGitHubIssuesFunction()
        : base(_serviceProvider)
    {
    }

    protected override async Task HandleFunctionAsync(Request<UpdateIssueRequest> input)
    {
        var githubService = ServiceProvider.GetService<IGitHubService>();
        await githubService.UpdateIssue(input.Data.Id, input.Data.Description);
    }
}
