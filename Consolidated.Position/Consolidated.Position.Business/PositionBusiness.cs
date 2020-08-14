using Consolidated.Position.Domain;
using Consolidated.Position.ExternalService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consolidated.Position.Business
{
    /// <summary>Interface do service de Posição</summary>
    public interface IPositionBusiness
    {
        Task<Consolidado> GerarPosicaoConsolidada();
    }

    /// <summary>Classe do service de Posição</summary>
    public class PositionBusiness : IPositionBusiness
    {
        /// <summary>Implementação da interface de posição</summary>
        private IPositionService PositionService { get; }

        /// <summary>Interface de configuração</summary>
        protected readonly IConfiguration Configuration;

        /// <summary>Interface de logger</summary>
        private ILogger<PositionBusiness> Logger { get; }

        /// <summary>Inicia uma nova instância da classe <see cref="PositionBusiness" />.</summary>
        /// <param name="logger">Interface de logger</param>
        /// <param name="positionService">Implementação da interface de posição</param>
        public PositionBusiness(
            ILoggerFactory logger,
            IConfiguration configuration,
            IPositionService positionService)
        {
            Logger = logger.CreateLogger<PositionBusiness>();
            Configuration = configuration;
            PositionService = positionService;
        }

        public async Task<Consolidado> GerarPosicaoConsolidada()
        {
            Logger.LogInformation("Iniciando geração de posição consolidada");

            TesouroDireto tesouroDireto = null;
            RendaFixa rendaFixa = null;
            Fundos fundosInvestimentos = null;

            await Task.WhenAll(
                    PositionService.ObterPosicaoTesouroDireto().ContinueWith(o => tesouroDireto = o.Result),
                    PositionService.ObterPosicaoRendaFixa().ContinueWith(o => rendaFixa = o.Result),
                    PositionService.ObterPosicaoFundos().ContinueWith(o => fundosInvestimentos = o.Result)
                );

            
            return fundosInvestimentos.MappingPosicoesToConsolidado(tesouroDireto, rendaFixa);
        }
    }
}
