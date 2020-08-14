using System;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Consolidated.Position.DI
{
    /// <summary>Classe de Dependency Injection.</summary>
    public interface ISerilogDI
    {
        /// <summary>Configuração logger ElasticSearch</summary>
        LoggerConfiguration ConfigurationSerilog();
    }

    /// <summary>Classe de Dependency Injection.</summary>
    public class SerilogDI : ISerilogDI
    {
        /// <summary>Interface Configuração</summary>
        public IConfiguration Configuration { get; }

        /// <summary>Inicia uma nova instância da classe <see cref="SerilogDI" />.</summary> 
        /// <param name="config">Configuração repository</param>
        public SerilogDI(IConfiguration config) => Configuration = config;

        /// <summary>Configuração logger ElasticSearch</summary>
        public LoggerConfiguration ConfigurationSerilog()
        {
            return new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.File(
                        path: "Logs/log-{Date}.txt",
                        fileSizeLimitBytes: 3000,
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning);
        }
    }
}
