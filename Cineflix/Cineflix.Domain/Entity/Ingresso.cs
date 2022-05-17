using Cineflix.Domain.Enum;
using System;

namespace Cineflix.Domain.Entity
{
    public class Ingresso
    {
        public Ingresso(int idUsuario, int idSessao, ETipoEntrada tipoEntrada, decimal valor)
        {
            IdUsuario = idUsuario;
            IdSessao = idSessao;
            TipoEntrada = tipoEntrada;
            Valor = valor;
            DataCompra = DateTime.Now;
        }

        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdSessao { get; private set; }
        public ETipoEntrada TipoEntrada { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCompra { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public virtual Sessao Sessao { get; private set; }
    }
}
