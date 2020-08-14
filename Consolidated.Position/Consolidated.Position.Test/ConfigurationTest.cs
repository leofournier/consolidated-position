using Consolidated.Position.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Consolidated.Position.Test
{
    public class ConfigurationTest
    {
        /// <summary>Loading de configuração</summary>
        public IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder();

            return builder.Build();
        }
        public ILoggerFactory LoggerFactoryConfiguration()
        {
            var log = new SerilogDI(LoadConfiguration()).ConfigurationSerilog().CreateLogger();
            var fac = new LoggerFactory();
            fac.AddSerilog(log);
            return fac;
        }
    }
}
