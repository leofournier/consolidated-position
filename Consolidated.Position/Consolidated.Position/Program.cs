using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Consolidated.Position
{
    /// <summary>
    /// Inicializador do serviço API
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Classe starting project
        /// </summary>
        /// <param name="args">Paramentro de entrada</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(config => { config.SetMinimumLevel(LogLevel.Information); });
    }
}
