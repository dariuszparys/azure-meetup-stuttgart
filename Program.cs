using Microsoft.AspNetCore.Hosting;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                                .UseKestrel()
                                .UseStartup<Startup>()
                                .Build();
            host.Run();
        }
    }
}
