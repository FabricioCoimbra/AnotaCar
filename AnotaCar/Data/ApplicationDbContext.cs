using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using AnotaCar.Models;
using AnotaCar.Data.Seeds;

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
        public DbSet<AnotaCar.Models.Marca> Marca { get; set; }
    }
}
