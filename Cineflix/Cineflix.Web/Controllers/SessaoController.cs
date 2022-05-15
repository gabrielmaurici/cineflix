using Cineflix.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cineflix.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoService _sessaoService;

        public SessaoController (ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpGet("BuscarSessoes")]
        public async Task<IActionResult> BuscarSessoes()
        {
            try
            {
                var resultado = await _sessaoService.BuscarSessoes();
                if (!resultado.Sucesso)
                    return NotFound(resultado.Mensagem);

                return Ok(resultado.Modelo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("BuscarSessaoPorid/{id}")]
        public async Task<IActionResult> BuscarSessaoPorId(int id)
        {
            try
            {
                var resultado = await _sessaoService.BuscarSessaoPorId(id);
                if (!resultado.Sucesso)
                    return NotFound(resultado.Mensagem);

                return Ok(resultado.Modelo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
