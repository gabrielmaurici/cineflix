using System.Threading.Tasks;

namespace Cineflix.Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<int> CadastraUsuario(Usuario model);
    }
}
