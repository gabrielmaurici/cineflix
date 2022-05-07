using System.Threading.Tasks;

namespace Cineflix.Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<int> CadastraUsuario(Usuario model);
        Task<bool> VerificaUsuarioExiste(string documento);
        Task<bool> VerificaSenhaExiste(string senhaHash);
    }
}
