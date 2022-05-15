using Cineflix.Domain;
using Cineflix.Domain.Repository;
using Cineflix.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cineflix.Infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CineflixContext _context;

        public UsuarioRepository(CineflixContext context)
        {
            _context = context;
        }

        public async Task<Usuario> BuscaUsuarioPorDocumento(string documento)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Documento.Equals(documento));
        }

        public async Task<int> CadastraUsuario(Usuario model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }

        public async Task<bool> VerificaDocumentoExiste(string documento)
        {
            return await _context.Usuarios.AnyAsync(x => x.Documento.Equals(documento));
        }

        public async Task<bool> VerificaSenhaExiste(string senhaHash)
        {
            return await _context.Usuarios.AnyAsync(x => x.Senha.Equals(senhaHash));
        }

        public async Task<bool> VerificaUsuarioExistePorId(int id)
        {
            return await _context.Usuarios.AnyAsync(x => x.Id == id);
        }
    }
}
