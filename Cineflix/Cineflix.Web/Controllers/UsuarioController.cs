using Cineflix.Domain.Dto;
using Cineflix.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cineflix.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CadastraUsuarioDto model)
        {
            var resultado = await _usuarioService.CadastraUsuario(model);

            if (!resultado.Sucesso)
                return NotFound("Falha ao cadastrar usuário");

            return Ok(resultado);
        }
    }
}
