using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApplication
{
    public class HomeController : Controller
    {
        private IGitHubService githubService;
        public HomeController(IGitHubService githubService)
        {
            this.githubService = githubService;
        }

        public IActionResult Index()
        {
            string result = githubService.GetZenMessage();
            return Ok(result);
        }
    }
}