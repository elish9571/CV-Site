using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Octokit;

namespace GitHubPortfolioService
{
    public class RepositoryDto
    {
        public string Name { get; set; }
        public string HtmlUrl { get; set; }
        public int StargazersCount { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Language { get; set; }
        public int PullRequestsCount { get; set; }
    }
    public class GitHubService : IGitHubService
    {
        private readonly GitHubClient _client;
        private readonly GitHubIntegrationOptions _options;

        public GitHubService(IOptions<GitHubIntegrationOptions> options)
        {
            _client = new GitHubClient(new ProductHeaderValue("my-github-app"));
            _options = options.Value;
        }

        public Task<List<RepositoryDto>> GetPortfolioAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetUserFollowersAsync(string userName)
        {
            var user = await _client.User.Get(userName);
            return user.Followers;
        }

        public Task<List<RepositoryDto>> SearchRepositoriesAsync(string? repoName = null, string? language = null, string? userName = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Repository>> SearchRepositoriesInCSharp()
        {
            var request = new SearchRepositoriesRequest("repo-name")
            {
                Language = Language.CSharp
            };
            var result = await _client.Search.SearchRepo(request);
            return result.Items.ToList();
        }
    }

}

