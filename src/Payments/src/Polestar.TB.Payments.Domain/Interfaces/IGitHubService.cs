using System.Collections.Generic;
using System.Threading.Tasks;
using Polestar.TB.Payments.Domain.Models;

namespace Polestar.TB.Payments.Domain.Interfaces;

public interface IGitHubService
{
    Task<IEnumerable<GitHubIssue>> GetIssues(int count);
    Task UpdateIssue(string id, string description);
}