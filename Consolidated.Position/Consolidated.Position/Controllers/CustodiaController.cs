using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Consolidated.Position.Business;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Consolidated.Position.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustodiaController : ControllerBase
    {
        /// <summary>Implementação da PositionBusiness</summary>
        private IPositionBusiness PositionBusiness { get; }

        /// <summary>Interface de logger</summary>
        private ILogger<CustodiaController> Logger { get; }

        /// <summary>Interface de Memory Cache</summary>
        private readonly IMemoryCache _cache;

        /// <summary>Inicia uma nova instância da classe <see cref="CustodiaController" />.</summary>
        /// <param name="logger">Interface de logger</param>
        /// <param name="positionBusiness">Implementação da PositionBusiness</param>
        /// <param name="cache">Interface de Memory Cache</param>
        public CustodiaController(ILoggerFactory logger, IPositionBusiness positionBusiness, IMemoryCache cache)
        {
            Logger = logger.CreateLogger<CustodiaController>();
            PositionBusiness = positionBusiness;
            _cache = cache;
        }

        /// <summary>Obtém posição consolidada</summary>     
        [Authorize("Bearer")]
        [HttpGet("[action]")]
        public async Task<IActionResult> ObterPosicaoConsolidada()
        {
            var cacheEntry = _cache.GetOrCreate("PositionCacheKey", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
                entry.SetPriority(CacheItemPriority.High);

                var retorno = await PositionBusiness.GerarPosicaoConsolidada();
                return Ok(retorno);
            });

            return await cacheEntry;
        }
    }
}
