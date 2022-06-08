using Cineflix.Domain.Cryptography;
using Cineflix.Domain.Dto;
using Cineflix.Domain.Models;
using Cineflix.Domain.Repository;
using Cineflix.Domain.Service;
using System.Threading.Tasks;

namespace Cineflix.Infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly CriptografiaService _criptografiaService;
        public LoginService(IUsuarioRepository usuarioRepository, CriptografiaService criptografiaService)
        {
            _usuarioRepository = usuarioRepository;
            _criptografiaService = criptografiaService;
        }

        public async Task<TypeResult<int>> RealizaLogin(LoginDto model)
        {
            try
            {
                model.Senha = _criptografiaService.CriptografaSenha(model.Senha);

                var loginValido = await _usuarioRepository.VerificaLoginUsuario(model);
                if (loginValido == 0)
                    return new TypeResult<int> { Sucesso = false, Mensagem = "Documento ou Senha inválidos" };

                return new TypeResult<int> { Sucesso = true, Modelo = loginValido };
            }
            catch
            {
                return new TypeResult<int> { Sucesso = false, Mensagem = "Ocorreu algum erro ao tentar realizar o login" };
            }
        }
    }
}
