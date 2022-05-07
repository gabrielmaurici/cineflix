namespace Cineflix.Domain.Entity
{
    public class Filme
    {
        public const short NOME_MAX = 45;
        public const short DESCRICAO_MAX = 100;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public short Duracao { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
