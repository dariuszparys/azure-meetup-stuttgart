using Microsoft.AspNetCore.Builder;

namespace ConsoleApplication
{
    public static class CountPathsExtension
    {
        public static IApplicationBuilder UseCountPaths(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CountPathsMiddleware>();
        }
    }
}