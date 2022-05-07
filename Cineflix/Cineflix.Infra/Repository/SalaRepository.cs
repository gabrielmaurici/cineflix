using Cineflix.Domain.Entity;
using Cineflix.Domain.Repository;
using Cineflix.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cineflix.Infra.Repository
{
    public class SalaRepository : ISalaRepository
    {
        private readonly CineflixContext _context;
        
        public SalaRepository(CineflixContext context)
        {
            _context = context;
        }


        public async Task<List<Sala>> BuscarSalas()
        {
            return await _context.Salas.ToListAsync();
        }
    }
}
