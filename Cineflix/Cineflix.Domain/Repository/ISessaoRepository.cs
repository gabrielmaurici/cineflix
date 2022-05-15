using Cineflix.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Domain.Repository
{
    public interface ISessaoRepository
    {
        Task<List<Sessao>> BuscarSessoes();
        Task<Sessao> BuscarSessaoPorId(int id);
    }
}
