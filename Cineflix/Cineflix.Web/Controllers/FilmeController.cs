using Cineflix.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Cineflix.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet("BuscarFilmes")]
        public async Task<IActionResult> BuscarFilmes()
        {
            try
            {
                var resultado = await _filmeService.BuscarFilmes();

                if (!resultado.Sucesso)
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
