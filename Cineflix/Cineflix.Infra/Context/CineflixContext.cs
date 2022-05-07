using Cineflix.Domain;
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
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}