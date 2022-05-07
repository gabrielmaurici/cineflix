using Cineflix.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cineflix.Infra.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Documento)
                .HasColumnName("Documento")
                .HasColumnType("varchar")
                .HasMaxLength(14);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(60);

            builder.Property(x => x.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar")
                .HasMaxLength(20);
        }
    }
}
