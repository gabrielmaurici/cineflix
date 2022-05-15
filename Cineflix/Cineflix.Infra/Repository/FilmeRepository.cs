using Cineflix.Domain.Entity;
using Cineflix.Domain.Repository;
using Cineflix.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Infra.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly CineflixContext _context;

        public FilmeRepository(CineflixContext context)
        {
            _context = context;
        }

        public async Task<List<Filme>> BuscarFilmes()
        {
            return await _context.Filmes.Include(x => x.Categoria).ToListAsync();
        }
    }
}
