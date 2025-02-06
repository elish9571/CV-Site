using GitHubPortfolioService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitHubPortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {

        private readonly IGitHubService _gitHubService;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        // GET: api/<GitHubController>
        [HttpGet("portfolio")]
        public async Task<IActionResult> GetPortfolio()
        {
            var repositories = await _gitHubService.GetPortfolioAsync();
            return Ok(repositories);
        }

        // GET api/<GitHubController>/5
        [HttpGet("search")]
        public async Task<IActionResult> SearchRepositories(
            [FromQuery] string? repoName = null,
            [FromQuery] string? language = null,
            [FromQuery] string? userName = null)
        {
            var repositories = await _gitHubService.SearchRepositoriesAsync(repoName, language, userName);
            return Ok(repositories);
        }
    }
}

