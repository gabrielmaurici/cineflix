using Cineflix.Domain.Entity;
using Cineflix.Domain.Repository;
using Cineflix.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Infra.Repository
{
    public class SessaoRepository : ISessaoRepository
    {
        private readonly CineflixContext _context;

        public SessaoRepository(CineflixContext context)
        {
            _context = context;
        }

        public async Task<Sessao> BuscarSessaoPorId(int id)
        {
            return await _context.Sessoes.Include(x => x.Filme)
                .ThenInclude(x => x.Categoria)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Sessao>> BuscarSessoes()
        {
            return await _context.Sessoes.Include(x => x.Filme).
                ThenInclude(x => x.Categoria).
                ToListAsync();
        }
    }
}
