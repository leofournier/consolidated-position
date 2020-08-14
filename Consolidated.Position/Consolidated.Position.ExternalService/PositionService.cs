using Consolidated.Position.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consolidated.Position.ExternalService
{
    /// <summary>Interface do service de Posição</summary>
    public interface IPositionService
    {
        /// <summary>Obter Posição de Tesouro Direto</summary>
        Task<TesouroDireto> ObterPosicaoTesouroDireto();

        /// <summary>Obter Posição de Renda Fixa</summary>
        Task<RendaFixa> ObterPosicaoRendaFixa();

        /// <summary>Obter Posição de Fundos de Investimentos</summary>
        Task<Fundos> ObterPosicaoFundos();
    }

    /// <summary>Classe do service de Posição</summary>
    public class PositionService : IPositionService
    {
        /// <summary>Interface de configuração</summary>
        protected readonly IConfiguration Configuration;

        /// <summary>Interface de logger</summary>
        private ILogger<PositionService> Logger { get; }

        /// <summary>Inicia uma nova instância da classe <see cref="PositionService" />.</summary> 
        /// <param name="configuration">Interface de configuração</param>
        /// <param name="logger">Interface de logger</param>
        public PositionService(IConfiguration configuration, ILoggerFactory logger)
        {
            Configuration = configuration;
            Logger = logger.CreateLogger<PositionService>();
        }

        /// <summary>Obter Posição de Tesouro Direto</summary>
        public async Task<TesouroDireto> ObterPosicaoTesouroDireto()
        {
            try
            {
                var restClient = new RestClient(Configuration["ExternalService:TesouroDireto"]);
                var restRequest = new RestRequest("", Method.GET, DataFormat.Json);

                var response = await restClient.ExecuteAsync(restRequest)
                    .ContinueWith(o =>
                    {
                        if (o.Exception != null)
                        {
                            Logger.LogError(o.Exception, "Erro ao obter posição de Tesouro Direto");
                            throw o.Exception;
                        }
                        else
                        {
                            var result = JsonConvert.DeserializeObject<TesouroDireto>(o.Result.Content);
                            return result;
                        }
                    });

                return response;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao obter posição de Tesouro Direto");
                throw ex;
            }
        }

        /// <summary>Obter Posição de Renda Fixa</summary>
        public async Task<RendaFixa> ObterPosicaoRendaFixa()
        {
            try
            {
                var restClient = new RestClient(Configuration["ExternalService:RendaFixa"]);
                var restRequest = new RestRequest("", Method.GET, DataFormat.Json);

                var response = await restClient.ExecuteAsync(restRequest)
                    .ContinueWith(o =>
                    {
                        if (o.Exception != null)
                        {
                            Logger.LogError(o.Exception, "Erro ao obter posição de Renda Fixa");
                            throw o.Exception;
                        }
                        else
                        {
                            var result = JsonConvert.DeserializeObject<RendaFixa>(o.Result.Content);
                            return result;
                        }
                    });

                return response;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao obter posição de Renda Fixa");
                throw ex;
            }
        }

        /// <summary>Obter Posição de Fundos de Investimentos</summary>
        public async Task<Fundos> ObterPosicaoFundos()
        {
            try
            {
                var restClient = new RestClient(Configuration["ExternalService:Fundos"]);
                var restRequest = new RestRequest("", Method.GET, DataFormat.Json);

                var response = await restClient.ExecuteAsync(restRequest)
                    .ContinueWith(o =>
                    {
                        if (o.Exception != null)
                        {
                            Logger.LogError(o.Exception, "Erro ao obter posição de Fundos de Investimentos");
                            throw o.Exception;
                        }
                        else
                        {
                            var result = JsonConvert.DeserializeObject<Fundos>(o.Result.Content);
                            return result;
                        }
                    });

                return response;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao obter posição de Fundos de Investimentos");
                throw ex;
            }
        }
    }
}
