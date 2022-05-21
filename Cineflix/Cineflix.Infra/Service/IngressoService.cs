using AutoMapper;
using Cineflix.Domain.Dto;
using Cineflix.Domain.Entity;
using Cineflix.Domain.Models;
using Cineflix.Domain.Repository;
using Cineflix.Domain.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Infra.Service
{
    public class IngressoService : IIngressoService
    {
        private readonly IIngressoRepository _ingressoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly EmailService _emailService;
        private readonly IMapper _mapper;

        public IngressoService(IIngressoRepository ingressoRepository, IUsuarioRepository usuarioRepository,
            EmailService emailService, IMapper mapper
        )
        {
            _ingressoRepository = ingressoRepository;
            _usuarioRepository = usuarioRepository;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<TypeResult<int>> GerarIngresso(GeraIngressoDto model)
        {
            try
            {
                var usuario = await _usuarioRepository.VerificaUsuarioExistePorId(model.IdUsuario);
                if(!usuario)
                    return new TypeResult<int> { Sucesso = false, Mensagem = "Usuário não encontrado" };

                var ingresso = new Ingresso(model.IdUsuario, model.IdSessao,model.TipoEntrada, model.Valor);

                var idIngresso = await _ingressoRepository.GerarIngresso(ingresso);
                if (idIngresso < 0)
                    return new TypeResult<int>() { Sucesso = false, Mensagem = "Ocorreu algum erro ao gravar ingresso, tente novamente!" };

               
                var enviaEmailRetorno = await EnviaIngressoPorEmail(idIngresso);
                if (!enviaEmailRetorno)
                    return new TypeResult<int>() { Sucesso = false, Mensagem = "Ocorreu algum erro no envio de email do ingresso, tente novamente!" };

                return new TypeResult<int> { Sucesso = true, Modelo = idIngresso };
            }
            catch (Exception ex)
            {
                return new TypeResult<int> { Sucesso = false, Mensagem = ex.Message };
            }
        }

        public async Task<TypeResult<RetornoIngressoUsuarioDto>> BuscarIngressoPorId(int id)
        {
            try
            {
                var ingresso = await _ingressoRepository.BuscarIngressoPorId(id);
                if (ingresso == null)
                    return new TypeResult<RetornoIngressoUsuarioDto> { Sucesso = false, Mensagem = "Não foi possível encontrar um ingresso com esse Id" };

                var ingressoTratado = _mapper.Map<RetornoIngressoUsuarioDto>(ingresso);

                return new TypeResult<RetornoIngressoUsuarioDto> { Sucesso = true, Modelo = ingressoTratado };
            }
            catch (Exception ex)
            {
                return new TypeResult<RetornoIngressoUsuarioDto> { Sucesso = false, Mensagem = ex.Message };
            }
        }

        public async Task<TypeResult<List<RetornoIngressoUsuarioDto>>> BuscarIngressosPorDocumento(string documento)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscaUsuarioPorDocumento(documento);
                if(usuario == null)
                    return new TypeResult<List<RetornoIngressoUsuarioDto>> { Sucesso = false, Mensagem = "Usuário não encontrado" };

                var ingressos = await _ingressoRepository.BuscarIngressosPorIdUsuario(usuario.Id);
                if(ingressos.Count <= 0)
                    return new TypeResult<List<RetornoIngressoUsuarioDto>> { Sucesso = false, Mensagem = "Não foram encontrados ingressos para este usuário"};

                var ingressosRetorno = TrataRetornoIngressos(ingressos);

                return new TypeResult<List<RetornoIngressoUsuarioDto>> { Sucesso = true, Modelo = ingressosRetorno };
            }
            catch (Exception ex)
            {
                return new TypeResult<List<RetornoIngressoUsuarioDto>> { Sucesso = false, Mensagem = ex.Message };
            }
        }
       
        private async Task<bool> EnviaIngressoPorEmail(int idIngresso)
        {
            var ingresso = await _ingressoRepository.BuscarIngressoPorId(idIngresso);

            var criaEmail = new EmailCriacaoIngresso(ingresso);
            var enviaEmailRetorno = await _emailService.EnviaEmail(criaEmail);
            if (!enviaEmailRetorno)
                return false;

            return true;
        }

        private List<RetornoIngressoUsuarioDto> TrataRetornoIngressos(List<Ingresso> ingressos)
        {
            var lista = new List<RetornoIngressoUsuarioDto>();

            foreach (var ingresso in ingressos)
            {
                lista.Add(_mapper.Map<RetornoIngressoUsuarioDto>(ingresso));
            }

            return lista;
        }
    }
}
