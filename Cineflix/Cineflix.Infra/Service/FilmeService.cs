using Cineflix.Domain.Entity;
using Cineflix.Domain.Models;
using Cineflix.Domain.Repository;
using Cineflix.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cineflix.Infra.Service
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<TypeResult<List<Filme>>> BuscarFilmes()
        {
            try
            {
                var filmes = await _filmeRepository.BuscarFilmes();
                if (filmes.Count <= 0)
                    return new TypeResult<List<Filme>> { Sucesso = false, Mensagem = "Nenhum filme registrado" };


                return new TypeResult<List<Filme>> { Sucesso = true, Modelo = filmes };
            }
            catch (Exception ex)
            {
                return new TypeResult<List<Filme>> { Sucesso = false, Mensagem = ex.Message };
            }
        }
    }
}
