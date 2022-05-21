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
            return await _context.Ingressos
                .Where(x => x.IdUsuario == idUsuario)
                .Include(x => x.Usuario)
                .Include(x => x.Sessao)
                .ThenInclude(x => x.Filme.Categoria)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<Ingresso> BuscarIngressoPorId(int id)
        {
            return await _context.Ingressos
                .Include(x => x.Usuario)
                .Include(x => x.Sessao.Filme)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}