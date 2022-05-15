using Cineflix.Domain.Dto;
using Cineflix.Domain.Entity;
using Cineflix.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Domain.Service
{
    public interface IIngressoService
    {
        Task<TypeResult<int>> GerarIngresso(GeraIngressoDto model);
        Task<TypeResult<List<Ingresso>>> BuscarIngressosPorDocumento(string documento);
    }
}
