using Cineflix.Domain.Enum;
using System;

namespace Cineflix.Domain.Dto
{
    public class RetornoIngressoUsuarioDto
    {
        public int Id { get; private set; }
        public string NomeUsuario { get; set; }
        public string DocumentoUsuario { get; set; }
        public ETipoEntrada TipoEntrada { get; private set; }
        public decimal Valor { get; private set; }
        public int Sala { get; set; }
        public string NomeFilme { get; set; }
        public short DuracaoFilme { get; set; }
        public DateTime DataSessao { get; set; }
        public DateTime DataCompra { get; private set; }
    }
}
