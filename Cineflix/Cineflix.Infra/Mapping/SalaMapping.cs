using Cineflix.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cineflix.Infra.Mapping
{
    public class SalaMapping : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("Sala");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NumeroSala)
                .HasColumnName("NumeroSala")
                .HasColumnType("tinyint")
                .HasMaxLength(Sala.NUMERO_SALA_MAX);

            builder.Property(x => x.Capacidade)
                .HasColumnName("Capacidade")
                .HasColumnType("samllint")
                .HasMaxLength(Sala.CAPACIDADE_MAX);
        }
    }
}
