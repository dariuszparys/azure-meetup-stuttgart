using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public interface IGitHubService
    {
        string GetZenMessage();
    }

    public class GitHubService : IGitHubService
    {
        string IGitHubService.GetZenMessage()
        {
            // HttpClient client = new HttpClient();
            // var response = await client.GetAsync("https://api.github.com/zen");
            // response.EnsureSuccessStatusCode();
            // return await response.Content.ReadAsStringAsync();
            return "This is it!";
        }
    }
}