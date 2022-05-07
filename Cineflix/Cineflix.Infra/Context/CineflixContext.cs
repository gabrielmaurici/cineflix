using Cineflix.Domain;
using Cineflix.Domain.Entity;
using Cineflix.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Cineflix.Infra.Context
{
    public class CineflixContext : DbContext
    {
        public CineflixContext(DbContextOptions<CineflixContext> opts) : base(opts)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new SalaMapping());
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
            modelBuilder.ApplyConfiguration(new FilmeMapping());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Categoria> Cateogrias { get; set; }
        public DbSet<Filme> Filmes{ get; set; }
    }
}