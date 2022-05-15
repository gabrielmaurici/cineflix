using Cineflix.Domain.Entity;
using Cineflix.Domain.Repository;
using Cineflix.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineflix.Infra.Repository
{
    public class IngressoRepository : IIngressoRepository
    {
        private readonly CineflixContext _context;

        public IngressoRepository(CineflixContext context)
        {
            _context = context;
        }

        public async Task<int> GerarIngresso(Ingresso model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }

        public async Task<List<Ingresso>> BuscarIngressosPorIdUsuario(int idUsuario)
        {
            return await _context.Ingressos.Include(x => x.Sessao)
                .ThenInclude(x => x.Filme.Categoria)
                .Where(x => x.IdUsuario == idUsuario)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
    }
}

