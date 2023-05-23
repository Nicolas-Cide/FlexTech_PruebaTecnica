using Banco.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Controllers
{
    [ApiController]
    public class BCRAController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public BCRAController(IRequestService requestService)
        {
            _requestService = requestService;
        }


        [HttpGet("bcra/movimientos/{cuenta}/credito")]
        public async Task<IActionResult> GetMovimientosCredito(string cuenta)
        {
            try
            {
                var movimientos = await _requestService.GetMovimientosByCuenta(cuenta);

                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor.");
            }
        }

    }
}
