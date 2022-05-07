using Cineflix.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Domain.Repository
{
    public interface IFilmeRepository
    {
        Task<List<Filme>> BuscarFilmes();
    }
}
