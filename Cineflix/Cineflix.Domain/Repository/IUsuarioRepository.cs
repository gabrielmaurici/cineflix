using System.Threading.Tasks;

namespace Cineflix.Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<int> CadastraUsuario(Usuario model);
        Task<Usuario> BuscaUsuarioPorDocumento(string documento);
        Task<bool> VerificaDocumentoExiste(string documento);
        Task<bool> VerificaSenhaExiste(string senhaHash);
        Task<bool> VerificaUsuarioExistePorId(int id);
    }
}
