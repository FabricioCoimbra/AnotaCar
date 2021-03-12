using AnotaCar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnotaCar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<TipoCombustivel> TipoCombustivel { get; set; }
        public DbSet<AnotaCar.Models.TipoVeiculo> TipoVeiculo { get; set; }
        public DbSet<AnotaCar.Models.Veiculo> Veiculo { get; set; }
    }
}
