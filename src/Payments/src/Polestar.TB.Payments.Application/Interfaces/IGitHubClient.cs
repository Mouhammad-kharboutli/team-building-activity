using System.Collections.Generic;
using System.Threading.Tasks;
using Polestar.TB.Payments.Domain.Models;

namespace Polestar.TB.Payments.Application.Interfaces;

public interface IGitHubClient
{
    Task<IEnumerable<GitHubIssue>> GetAspNetDocsIssuesAsync();
}
