using Cineflix.Domain.Enum;

namespace Cineflix.Domain.Dto
{
    public class GeraIngressoDto
    {
        public int IdUsuario { get; set; }
        public int IdSessao { get; set; }
        public ETipoEntrada TipoEntrada { get; set; }
        public decimal Valor { get; set; }
    }
}
