using System;

namespace Cineflix.Domain.Entity
{
    public class Sessao
    {
        public int Id { get; set; }
        public int IdFilme { get; set; }
        public int IdSala { get; set; }
        public virtual Filme Filme { get; set; }
        public DateTime DataSessao { get; set; }
    }
}
