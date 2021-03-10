using AnotaCar.Models;
using Microsoft.EntityFrameworkCore;

namespace AnotaCar.Data.Seeds
{
    public class MarcaSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            var contemMarcas = context.Marca.FirstOrDefaultAsync().Result != null;
            if (contemMarcas)            
                return;

            context.Marca.AddRange(
                    new Marca() { Id = 1, Descricao = "Chevrolet" },
                    new Marca() { Id = 2, Descricao = "Volkswagen" },
                    new Marca() { Id = 3, Descricao = "Fiat" },
                    new Marca() { Id = 4, Descricao = "Renault" },
                    new Marca() { Id = 5, Descricao = "Ford" },
                    new Marca() { Id = 6, Descricao = "Toyota" },
                    new Marca() { Id = 7, Descricao = "Hyundai" },
                    new Marca() { Id = 8, Descricao = "Jeep" },
                    new Marca() { Id = 9, Descricao = "Honda" },
                    new Marca() { Id = 10, Descricao = "Nissan" },
                    new Marca() { Id = 11, Descricao = "Citroën" },
                    new Marca() { Id = 12, Descricao = "Mitsubishi" },
                    new Marca() { Id = 13, Descricao = "Peugeot" },
                    new Marca() { Id = 14, Descricao = "Chery" },
                    new Marca() { Id = 15, Descricao = "BMW" },
                    new Marca() { Id = 16, Descricao = "Mercedes-Benz" },
                    new Marca() { Id = 17, Descricao = "Kia" },
                    new Marca() { Id = 18, Descricao = "Audi" },
                    new Marca() { Id = 19, Descricao = "Volvo" },
                    new Marca() { Id = 20, Descricao = "Land Rover" },
                    new Marca() { Id = 21, Descricao = "Ferrari" },
                    new Marca() { Id = 22, Descricao = "JAC" },
                    new Marca() { Id = 23, Descricao = "Jaguar" },
                    new Marca() { Id = 24, Descricao = "Lexus" },
                    new Marca() { Id = 25, Descricao = "Maserati" },
                    new Marca() { Id = 26, Descricao = "Mini" },
                    new Marca() { Id = 27, Descricao = "Porshe" },
                    new Marca() { Id = 28, Descricao = "Rolls-Royce" },
                    new Marca() { Id = 29, Descricao = "Subaru" },
                    new Marca() { Id = 30, Descricao = "Troller" }
                );
            _ = context.SaveChangesAsync().Result;
        }
    }
}
