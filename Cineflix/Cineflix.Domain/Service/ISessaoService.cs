using Cineflix.Domain.Entity;
using Cineflix.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Domain.Service
{
    public interface ISessaoService
    {
        Task<TypeResult<List<Sessao>>> BuscarSessoes();
        Task<TypeResult<Sessao>> BuscarSessaoPorId(int id);
    }
}
