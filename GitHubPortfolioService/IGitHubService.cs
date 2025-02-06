using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubPortfolioService
{
    public interface IGitHubService
    {
        Task<List<RepositoryDto>> GetPortfolioAsync();
        Task<List<RepositoryDto>> SearchRepositoriesAsync(string? repoName = null, string? language = null, string? userName = null);
    }
}
