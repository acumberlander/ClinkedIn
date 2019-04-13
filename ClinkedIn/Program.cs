using ClinkedIn.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ClinkedIn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            var Jasmine = new Clinker("Jasmine", "jas");
            var Austin = new Clinker("Austin", "aus");
            var Marshall = new Clinker("Marshall", "mars");

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
