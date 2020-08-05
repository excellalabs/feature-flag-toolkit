using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FeatureFlags.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FeatureFlags
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public async static Task Main(string[] args)
        {
            var flags = await GetFlags();
            JArray j = JArray.Parse(flags);
            CreateHostBuilder(args).Build().Run();
        }

        private static async Task<string> GetFlags()
        {
            return await client.GetStringAsync("http://localhost:18000/api/v1/flags");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
