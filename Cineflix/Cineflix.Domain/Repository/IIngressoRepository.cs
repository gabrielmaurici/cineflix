using Cineflix.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Domain.Repository
{
    public interface IIngressoRepository
    {
        Task<int> GerarIngresso(Ingresso model);
        Task<List<Ingresso>> BuscarIngressosPorIdUsuario(int idUsuario);
    }
}
