using AutoMapper;
using Cineflix.Domain.Dto;
using Cineflix.Domain.Entity;

namespace Cineflix.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ingresso, RetornoIngressoUsuarioDto>()
            .ForMember(x => x.NomeUsuario, x => x.MapFrom(x => x.Usuario.Nome))
            .ForMember(x => x.DocumentoUsuario, x => x.MapFrom(x => x.Usuario.Documento))
            .ForMember(x => x.Sala, x => x.MapFrom(x => x.Sessao.IdSala))
            .ForMember(x => x.NomeFilme, x => x.MapFrom(x => x.Sessao.Filme.Nome))
            .ForMember(x => x.DuracaoFilme, x => x.MapFrom(x => x.Sessao.Filme.Duracao))
            .ForMember(x => x.DataSessao, x => x.MapFrom(x => x.Sessao.DataSessao));
        }
    }
}
