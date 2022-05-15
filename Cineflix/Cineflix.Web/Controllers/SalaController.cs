using Cineflix.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Cineflix.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;

        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        [HttpGet("BuscaSalas")]
        public async Task<IActionResult> BuscaSalas()
        {
            try
            {
                var resultado = await _salaService.BuscarSalas();
                if(!resultado.Sucesso)
                    return Conflict(resultado.Mensagem);

                return Ok(resultado.Modelo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
