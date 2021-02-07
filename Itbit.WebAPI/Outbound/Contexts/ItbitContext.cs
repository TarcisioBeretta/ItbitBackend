using Itbit.WebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Itbit.WebAPI.Outbound.Contexts
{
    public class ItbitContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sexo> Sexos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ItbitDB;Trusted_Connection=true;");
        }
    }
}
