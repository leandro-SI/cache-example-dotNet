using CacheEx.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CacheEx.API.Context
{
    public class CacheContext : DbContext
    {

        public CacheContext(DbContextOptions<CacheContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 1,
                Nome = "Leandro",
                Sobrenome = "Cesar",
                Idade = 32
            });

            modelBuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 2,
                Nome = "Silvio",
                Sobrenome = "Cesar",
                Idade = 67
            });

            modelBuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 3,
                Nome = "Luciana",
                Sobrenome = "Santos",
                Idade = 50
            });

            modelBuilder.Entity<Pessoa>().HasData(new Pessoa
            {
                Id = 4,
                Nome = "Dayanne",
                Sobrenome = "Santos",
                Idade = 27
            });
        }
    }
}
