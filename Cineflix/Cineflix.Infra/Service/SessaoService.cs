using Cineflix.Domain.Entity;
using Cineflix.Domain.Models;
using Cineflix.Domain.Repository;
using Cineflix.Domain.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Infra.Service
{
    public class SessaoService : ISessaoService
    {
        private readonly ISessaoRepository _sessaoRepository;

        public SessaoService(ISessaoRepository sessaoRepository)
        {
            _sessaoRepository = sessaoRepository;
        }

        public async Task<TypeResult<List<Sessao>>> BuscarSessoes()
        {
            try
            {
                var sessoes = await _sessaoRepository.BuscarSessoes();
                if (sessoes.Count <= 0)
                    return new TypeResult<List<Sessao>> { Sucesso = false, Mensagem = "Não existem sessões registradas" };

                return new TypeResult<List<Sessao>> { Sucesso = true, Modelo = sessoes };
            }
            catch (Exception ex)
            {
                return new TypeResult<List<Sessao>> { Sucesso = false, Mensagem = ex.Message };
            }
        }

        public async Task<TypeResult<Sessao>> BuscarSessaoPorId(int id)
        {
            try
            {
                var sessao = await _sessaoRepository.BuscarSessaoPorId(id);
                if (sessao == null)
                    return new TypeResult<Sessao> { Sucesso = false, Mensagem = "Nenhuma sessão encontrada com este Id" };

                return new TypeResult<Sessao> { Sucesso = true, Modelo = sessao };
            }
            catch (Exception ex)
            {
                return new TypeResult<Sessao> { Sucesso = false, Mensagem = ex.Message };
            }
        }
    }
}
