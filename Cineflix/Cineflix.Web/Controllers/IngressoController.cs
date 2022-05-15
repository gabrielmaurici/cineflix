using Cineflix.Domain.Dto;
using Cineflix.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cineflix.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngressoController : ControllerBase
    {
        private readonly IIngressoService _ingressoService;

        public IngressoController(IIngressoService ingressoService)
        {
            _ingressoService = ingressoService;
        }

        [HttpPost("GerarIngresso")]
        public async Task<IActionResult> GerarIngresso([FromBody] GeraIngressoDto model)
        {
            try
            {
                var resultado = await _ingressoService.GerarIngresso(model);
                if(!resultado.Sucesso)
                    return NotFound(resultado.Mensagem);

                return Ok(resultado.Modelo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("BusacrIngressosPorIdCliente/{documento}")]
        public async Task<IActionResult> BuscarIngressosPorIdCliente(string documento)
        {
            try
            {
                var resultado = await _ingressoService.BuscarIngressosPorDocumento(documento);
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
