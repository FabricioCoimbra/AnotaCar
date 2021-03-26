using AnotaCar.Models;
using Microsoft.EntityFrameworkCore;

namespace AnotaCar.Data.Seeds
{
    public class TipoVeiculoSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            var contemTipoVeiculo = context.TipoVeiculo.FirstOrDefaultAsync().Result != null;
            if (contemTipoVeiculo)
                return;
            context.TipoVeiculo.AddRange(
                    new TipoVeiculo() { Descricao = "Carro" },
                    new TipoVeiculo() { Descricao = "Moto" },
                    new TipoVeiculo() { Descricao = "Camionete" },
                    new TipoVeiculo() { Descricao = "Caminhão" }
                    );
            _ = context.SaveChangesAsync().Result;
        }
    }
}
