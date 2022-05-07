using Cineflix.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cineflix.Infra.Mapping
{
    public class FilmeMapping : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filme");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(Filme.NOME_MAX);

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(Filme.DESCRICAO_MAX);

            builder.Property(x => x.Duracao)
                .HasColumnName("Duracao")
                .HasColumnType("smallint");

            builder.Property(x => x.IdCategoria)
                .HasColumnName("IdCategoria")
                .HasColumnType("int");
        }
    }
}
