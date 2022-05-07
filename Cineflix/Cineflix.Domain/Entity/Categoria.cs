using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cineflix.Domain.Entity
{
    public class Categoria
    {
        public const int NOME_MAX = 45;

        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<Filme> Filmes { get; set; }
    }
}
