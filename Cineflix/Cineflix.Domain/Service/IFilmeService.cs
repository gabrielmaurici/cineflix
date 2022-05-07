using Cineflix.Domain.Entity;
using Cineflix.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Domain.Service
{
    public interface IFilmeService
    {
        Task<TypeResult<List<Filme>>> BuscarFilmes();
    }
}
