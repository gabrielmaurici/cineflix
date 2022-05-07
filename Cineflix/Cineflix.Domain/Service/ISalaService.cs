using Cineflix.Domain.Entity;
using Cineflix.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Domain.Service
{
    public interface ISalaService
    {
        Task<TypeResult<List<Sala>>> BuscarSalas();
    }
}
