using GitHubPortfolioService;
using Microsoft.Extensions.Caching.Memory;

namespace GitHubPortfolioAPI
{
    public class CachedGithubService : IGitHubService
    {
        private readonly IGitHubService _gitHubService;
        private readonly IMemoryCache _memoryCache;

        private const string UserPortfolioKey = "UserPortfollioKey";

        public CachedGithubService(IGitHubService gitHubService, IMemoryCache memoryCache)
        {
            _gitHubService = gitHubService;
            _memoryCache = memoryCache;
        }

        public async Task<List<RepositoryDto>> GetPortfolioAsync()
        {
            if (_memoryCache.TryGetValue(UserPortfolioKey, out List<RepositoryDto> repositoryDto))
                return repositoryDto;
            var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(30)).SetSlidingExpiration(TimeSpan.FromSeconds(10));
            repositoryDto = await _gitHubService.GetPortfolioAsync();
            _memoryCache.Set(UserPortfolioKey, repositoryDto, cacheOptions);
            return repositoryDto;
        }

        public Task<List<RepositoryDto>> SearchRepositoriesAsync(string? repoName = null, string? language = null, string? userName = null)
        {
            return _gitHubService.SearchRepositoriesAsync(repoName, language, userName);
        }
    }
}