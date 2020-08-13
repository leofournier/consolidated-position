using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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

        /// <summary>
        /// Construtor do host
        /// </summary>
        /// <param name="args">Parametro de entrada</param>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
