using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGitHubService, GitHubService>();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseCountPaths();
            app.UseMvcWithDefaultRoute();

            loggerFactory.AddConsole();
            var logger = loggerFactory.CreateLogger<Startup>();

            app.Map("/time", Alternate);

            app.Use(async (context, next) =>
           {
               logger.LogInformation($"Request {context.Request.Path} started");
               await next.Invoke();
               logger.LogInformation($"Request {context.Request.Path} finished");
           });

            app.Run(context =>
           {
               logger.LogInformation("write handler");
               return context.Response.WriteAsync("Hello from ASP.NET Core");
           });
        }

        public void Alternate(IApplicationBuilder app)
        {
            app.Run(context =>
            {
                // return context.Response.WriteAsync($"The time is {DateTime.Now}");
                return context.Response.WriteAsync($"This is {System.Environment.MachineName}");
            });
        }
    }
}