using AnotaCar.Models;
using Microsoft.EntityFrameworkCore;

namespace AnotaCar.Data.Seeds
{
    public class TipoCombustivelSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            var contemTipoCombustivel = context.TipoCombustivel.FirstOrDefaultAsync().Result != null;
            if (contemTipoCombustivel)
                return;
            context.TipoCombustivel.AddRange(
                    new TipoCombustivel() { Descricao = "Gasolina Comum" },
                    new TipoCombustivel() { Descricao = "Gasolina Aditivada" },
                    new TipoCombustivel() { Descricao = "Etanol" },
                    new TipoCombustivel() { Descricao = "Diesel" }
                    );
            _ = context.SaveChangesAsync().Result;
        }
    }
}
