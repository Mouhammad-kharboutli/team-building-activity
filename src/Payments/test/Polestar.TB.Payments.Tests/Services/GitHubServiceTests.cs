using System;
using System.Threading.Tasks;
using Polestar.TB.Payments.Application.Options;
using Polestar.TB.Payments.Application.Services;
using Xunit;
using System.Linq;
using Polestar.TB.Payments.Application.Interfaces;
using Bogus;
using Moq;
using Polestar.TB.Payments.Domain.Models;

namespace Polestar.TB.Payments.Tests.Services;

public class GitHubServiceTests
{
    private readonly Mock<IGitHubClient> _client;
    private readonly GitHubService _sut;

    public GitHubServiceTests()
    {
        _client = new Mock<IGitHubClient>();
        _sut = new GitHubService(new Mock<FooOptions>().Object, _client.Object);
    }

    [Fact]
    public void Constructor_NullInitialization_ThrowsArgumentNullException() =>
        Assert.Throws<ArgumentNullException>(() => new GitHubService(null, null));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(10, 10)]
    [InlineData(11, 10)]
    public async Task GetIssues_MultipleIssues_ReturnsWithCorrectCount(int issuesCount, int expectedCount)
    {
        var issues = new Faker<GitHubIssue>()
            .RuleFor(u => u.id, f => f.Random.Number())
            .RuleFor(u => u.body, f => f.Lorem.Sentences(2))
            .RuleFor(u => u.title, f => f.Lorem.Sentence(1));

        _client.Setup(c => c.GetAspNetDocsIssuesAsync()).ReturnsAsync(issues.Generate(issuesCount).ToArray());

        var result = await _sut.GetIssues(10);

        Assert.Equal(expectedCount, result.Count());
    }
}