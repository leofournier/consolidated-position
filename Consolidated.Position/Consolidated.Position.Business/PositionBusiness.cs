﻿using Consolidated.Position.Domain;
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
        /// <summary>Gera posição consolidada de todos os ativos</summary>
        Task<Consolidado> GerarPosicaoConsolidada();
        
        /// <summary>Gera posição consolidada de todos os ativos</summary>
        Task<Consolidado> GerarPosicaoTesouroDireto();
        
        /// <summary>Gera posição consolidada de todos os ativos</summary>
        Task<Consolidado> GerarPosicaoRendaFixa();
        
        /// <summary>Gera posição consolidada de todos os ativos</summary>
        Task<Consolidado> GerarPosicaoFundos();

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

        /// <summary>Gera posição consolidada de todos os ativos</summary>
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

        /// <summary>Gera posição consolidada de todos os ativos</summary>
        public async Task<Consolidado> GerarPosicaoTesouroDireto()
        {
            Logger.LogInformation("Iniciando geração de posição em Tesouro Direto");

            TesouroDireto tesouroDireto = null;

            await PositionService.ObterPosicaoTesouroDireto().ContinueWith(o => tesouroDireto = o.Result);

            return tesouroDireto.MappingTesouroDiretoToConsolidado();
        }

        /// <summary>Gera posição consolidada de todos os ativos</summary>
        public async Task<Consolidado> GerarPosicaoFundos()
        {
            Logger.LogInformation("Iniciando geração de posição em Tesouro Direto");

            Fundos fundos = null;

            await PositionService.ObterPosicaoFundos().ContinueWith(o => fundos = o.Result);

            return fundos.MappingFundosToConsolidado();
        }

        /// <summary>Gera posição em Renda Fixa</summary>
        public async Task<Consolidado> GerarPosicaoRendaFixa()
        {
            Logger.LogInformation("Iniciando geração de posição em Renda Fixa");

            RendaFixa rendaFixa = null;

            await PositionService.ObterPosicaoRendaFixa().ContinueWith(o => rendaFixa = o.Result);

            return rendaFixa.MappingRendaFixaToConsolidado();
        }
    }
}
