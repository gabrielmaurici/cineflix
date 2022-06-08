using Cineflix.Domain.Dto;
using Cineflix.Domain.Models;
using System.Threading.Tasks;

namespace Cineflix.Domain.Service
{
    public interface ILoginService
    {
        Task<TypeResult<int>> RealizaLogin(LoginDto model);
    }
}
