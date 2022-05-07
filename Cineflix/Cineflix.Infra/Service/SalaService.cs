using Cineflix.Domain.Entity;
using Cineflix.Domain.Models;
using Cineflix.Domain.Repository;
using Cineflix.Domain.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cineflix.Infra.Service
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _salaRepository;

        public SalaService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task<TypeResult<List<Sala>>> BuscarSalas()
        {
            try
            {
                var salas = await _salaRepository.BuscarSalas();
                if(salas.Count <= 0)
                    return new TypeResult<List<Sala>> { Sucesso = false, Mensagem = "Nenhuma sala registrada" };

                return new TypeResult<List<Sala>> { Sucesso = true, Modelo = salas };
            }
            catch (Exception ex)
            {
                return new TypeResult<List<Sala>> { Sucesso = false, Mensagem = ex.Message };
            }
        }
    }
}
