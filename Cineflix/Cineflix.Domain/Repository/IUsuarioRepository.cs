using Cineflix.Domain.Dto;
using System.Threading.Tasks;

namespace Cineflix.Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<int> CadastraUsuario(Usuario model);
        Task<Usuario> BuscaUsuarioPorDocumento(string documento);
        Task<Usuario> BuscaUsuarioPorId(int id);
        Task<bool> VerificaDocumentoExiste(string documento);
        Task<bool> VerificaSenhaExiste(string senhaHash);
        Task<bool> VerificaUsuarioExistePorId(int id);
        Task<int> VerificaLoginUsuario(LoginDto model);
    }
}
