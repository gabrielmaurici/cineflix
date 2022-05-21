using Cineflix.Domain.Dto;
using Cineflix.Domain.Models;
using System.Threading.Tasks;

namespace Cineflix.Domain.Service
{
    public interface IUsuarioService
    {
        Task<TypeResult<int>> CadastraUsuario(CadastraUsuarioDto model);
        Task<TypeResult<Usuario>> BuscaUsuarioPorId(int id);
    }
}
