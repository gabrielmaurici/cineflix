using Cineflix.Domain;
using Cineflix.Domain.Cryptography;
using Cineflix.Domain.Dto;
using Cineflix.Domain.Models;
using Cineflix.Domain.Repository;
using Cineflix.Domain.Service;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Cineflix.Infra.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly CriptografiaService _criptografiaService;
        private readonly EmailService _emailService;

        public UsuarioService(IUsuarioRepository usuarioRepository, EmailService emailService, CriptografiaService criptografiaService)
        {
            _usuarioRepository = usuarioRepository;
            _emailService = emailService;
            _criptografiaService = criptografiaService;
        }

        public async Task<TypeResult<int>> CadastraUsuario(CadastraUsuarioDto model)
        {
            try
            {
                var senhaCriptografada = _criptografiaService.CriptografaSenha(model.Senha);

                if(await _usuarioRepository.VerificaDocumentoExiste(model.Documento))
                    return new TypeResult<int> { Sucesso = false, Mensagem = "Usuário já existente" };

                if (await _usuarioRepository.VerificaSenhaExiste(senhaCriptografada))
                    return new TypeResult<int> { Sucesso = false, Mensagem = "Senha já existente, tente outra combinação" };

                var usuario = new Usuario();
                usuario.CriarUsuario(model.Documento, senhaCriptografada, model.Email, model.Nome);

                var idUsuario = await _usuarioRepository.CadastraUsuario(usuario);
                if (idUsuario < 0)
                    return new TypeResult<int>() { Sucesso = false, Mensagem = "Ocorreu algum erro ao tentar cadastrar, tente novamente!" };

                var criaEmail = new EmailCriacaoUsuario(model.Email, model.Nome);
                var enviaEmailRetorno = await _emailService.EnviaEmail(criaEmail);
                if (!enviaEmailRetorno)
                    return new TypeResult<int>() { Sucesso = false, Mensagem = "Ocorreu algum erro no envio de email de novo usuário" };

                return new TypeResult<int> { Sucesso = true, Modelo = idUsuario }; 
            }
            catch (Exception ex)
            {
                return new TypeResult<int> { Sucesso = false, Mensagem = ex.Message };
            }
        }

        public async Task<TypeResult<Usuario>> BuscaUsuarioPorId(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscaUsuarioPorId(id);
                if (usuario == null)
                    return new TypeResult<Usuario> { Sucesso = false, Mensagem = "Usuário não encontrado" };

                return new TypeResult<Usuario> { Sucesso = true, Modelo = usuario };
            }
            catch (Exception ex)
            {
                return new TypeResult<Usuario> { Sucesso = false, Mensagem = ex.Message };
            }
        }
    }
}
