using Microsoft.EntityFrameworkCore;

namespace Prueba2.Models
{
    public class PruebaContext : DbContext
    {
        public PruebaContext(DbContextOptions<PruebaContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Usuarios>().HasIndex(u => u.Nombre).IsUnique();
            modelBuilder.Entity<Rol>().HasIndex(r => r.Nombre).IsUnique();
        }
    }
}
