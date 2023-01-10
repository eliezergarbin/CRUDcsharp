using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Data
{
    public class HeroiContext : DbContext
    {
        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Arma> Armas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;Initial Catalog=HeroApp;Data Source=DESKTOP-NQK9MJ8");
        }
    }
}
