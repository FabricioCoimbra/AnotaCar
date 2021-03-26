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
                    new Marca() { Descricao = "Chevrolet" },
                    new Marca() { Descricao = "Volkswagen" },
                    new Marca() { Descricao = "Fiat" },
                    new Marca() { Descricao = "Renault" },
                    new Marca() { Descricao = "Ford" },
                    new Marca() { Descricao = "Toyota" },
                    new Marca() { Descricao = "Hyundai" },
                    new Marca() { Descricao = "Jeep" },
                    new Marca() { Descricao = "Honda" },
                    new Marca() { Descricao = "Nissan" },
                    new Marca() { Descricao = "Citroën" },
                    new Marca() { Descricao = "Mitsubishi" },
                    new Marca() { Descricao = "Peugeot" },
                    new Marca() { Descricao = "Chery" },
                    new Marca() { Descricao = "BMW" },
                    new Marca() { Descricao = "Mercedes-Benz" },
                    new Marca() { Descricao = "Kia" },
                    new Marca() { Descricao = "Audi" },
                    new Marca() { Descricao = "Volvo" },
                    new Marca() { Descricao = "Land Rover" },
                    new Marca() { Descricao = "Ferrari" },
                    new Marca() { Descricao = "JAC" },
                    new Marca() { Descricao = "Jaguar" },
                    new Marca() { Descricao = "Lexus" },
                    new Marca() { Descricao = "Maserati" },
                    new Marca() { Descricao = "Mini" },
                    new Marca() { Descricao = "Porshe" },
                    new Marca() { Descricao = "Rolls-Royce" },
                    new Marca() { Descricao = "Subaru" },
                    new Marca() { Descricao = "Troller" }
                );
            _ = context.SaveChangesAsync().Result;
        }
    }
}
