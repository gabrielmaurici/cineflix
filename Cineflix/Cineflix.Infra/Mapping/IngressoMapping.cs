using Cineflix.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cineflix.Infra.Mapping
{
    public class IngressoMapping : IEntityTypeConfiguration<Ingresso>
    {
        public void Configure(EntityTypeBuilder<Ingresso> builder)
        {
            builder.ToTable("Ingresso");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdUsuario)
                .HasColumnName("IdUsuario")
                .HasColumnType("int");

            builder.Property(x => x.IdSessao)
                .HasColumnName("IdSessao")
                .HasColumnType("int");

            builder.Property(x => x.TipoEntrada)
                .HasColumnName("TipoEntrada")
                .HasColumnType("enum");

            builder.Property(x => x.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal");

            builder.Property(x => x.DataCompra)
                .HasColumnName("DataCompra")
                .HasColumnType("datetime");

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.IdUsuario);

            builder.HasOne(x => x.Sessao)
                .WithMany()
                .HasForeignKey(x => x.IdSessao);
        }
    }
}
