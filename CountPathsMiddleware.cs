using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ConsoleApplication
{
    public class CountPathsMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        private Dictionary<string, int> pathCounts = new Dictionary<string, int>();
        public CountPathsMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory.CreateLogger<CountPathsMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            if (pathCounts.ContainsKey(context.Request.Path))
            {
                pathCounts[context.Request.Path] += 1;
            }
            else
            {
                pathCounts.Add(context.Request.Path, 1);
            }
            this.logger.LogInformation($"Path {context.Request.Path} called {pathCounts[context.Request.Path]} times");

            await this.next.Invoke(context);
        }
    }
}