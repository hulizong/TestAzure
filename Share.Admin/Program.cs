using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;

namespace Share.Admin
{
    public class Program
    {
        public static string host;
        public static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
          .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
          .Build();
            host = config["Setting:Host"];
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
              .UseUrls(host)
                .UseStartup<Startup>();
    }
}
