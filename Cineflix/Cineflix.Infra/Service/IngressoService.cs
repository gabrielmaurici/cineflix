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

        public IngressoService(IIngressoRepository ingressoRepository, IUsuarioRepository usuarioRepository)
        {
            _ingressoRepository = ingressoRepository;
            _usuarioRepository = usuarioRepository;
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

                return new TypeResult<int> { Sucesso = true, Modelo = idIngresso };
            }
            catch (Exception ex)
            {
                return new TypeResult<int> { Sucesso = false, Mensagem = ex.Message };
            }
        }

        // Tratar retorno para não mostrar dados sensíveis de cliente
        public async Task<TypeResult<List<Ingresso>>> BuscarIngressosPorDocumento(string documento)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscaUsuarioPorDocumento(documento);
                if(usuario == null)
                    return new TypeResult<List<Ingresso>> { Sucesso = false, Mensagem = "Usuário não encontrado" };

                var ingressos = await _ingressoRepository.BuscarIngressosPorIdUsuario(usuario.Id);
                if(ingressos.Count <= 0)
                    return new TypeResult<List<Ingresso>> { Sucesso = false, Mensagem = "Não foram encontrados ingressos para este usuário"};

                return new TypeResult<List<Ingresso>> { Sucesso = true, Modelo = ingressos };
            }
            catch (Exception ex)
            {
                return new TypeResult<List<Ingresso>> { Sucesso = false, Mensagem = ex.Message };
            }
        }
    }
}
