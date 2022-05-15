using Cineflix.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cineflix.Infra.Mapping
{
    public class SessaoMapping : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("Sessao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdFilme)
                .HasColumnName("IdFilme")
                .HasColumnType("int");

            builder.Property(x => x.IdSala)
                .HasColumnName("IdSala")
                .HasColumnType("int");

            builder.HasOne(x => x.Filme)
                .WithMany()
                .HasForeignKey(x => x.IdFilme);
        }
    }
}
