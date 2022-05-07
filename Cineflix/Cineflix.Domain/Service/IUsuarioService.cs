using Cineflix.Domain.Dto;
using Cineflix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cineflix.Domain.Service
{
    public interface IUsuarioService
    {
        Task<TypeResult<int>> CadastraUsuario(CadastraUsuarioDto model);
    }
}
