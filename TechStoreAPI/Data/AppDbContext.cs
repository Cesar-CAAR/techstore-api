using Microsoft.EntityFrameworkCore;
using TechStoreAPI.Models;

namespace TechStoreAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Mapea la clase Componente con la tabla "componentes" de Neon
        public DbSet<Componente> Componentes { get; set; }
    }
}