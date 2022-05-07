namespace Cineflix.Domain.Entity
{
    public class Sala
    {
        public const short NUMERO_SALA_MAX = 1;
        public const short CAPACIDADE_MAX = 3;

        public int Id { get; set; }
        public byte NumeroSala { get; set; }
        public short Capacidade { get; set; }

    }
}
