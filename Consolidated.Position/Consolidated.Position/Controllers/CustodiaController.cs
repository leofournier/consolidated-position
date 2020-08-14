using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Consolidated.Position.Business;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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

        /// <summary>Inicia uma nova instância da classe <see cref="CustodiaController" />.</summary>
        /// <param name="logger">Interface de logger</param>
        /// <param name="positionBusiness">Implementação da PositionBusiness</param>
        public CustodiaController(ILoggerFactory logger, IPositionBusiness positionBusiness)
        {
            Logger = logger.CreateLogger<CustodiaController>();
            PositionBusiness = positionBusiness;
        }

        /// <summary>Obtém posição consolidada</summary>     
        //[Authorize("Bearer")]
        [HttpGet("[action]")]
        public async Task<IActionResult> ObterPosicaoConsolidada()
        {
            var retorno = await PositionBusiness.GerarPosicaoConsolidada();
            return Ok(retorno);
        }
    }
}
