using Cineflix.Domain;
using Cineflix.Domain.Dto;
using Cineflix.Domain.Repository;
using Cineflix.Infra.Context;
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

        public async Task<int> CadastraUsuario(Usuario model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }
    }
}
