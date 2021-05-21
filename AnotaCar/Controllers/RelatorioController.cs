using AnotaCar.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnotaCar.Controllers
{
    public class RelatorioController : Controller
    {
        private const int NumeroMesesConsiderar = 12;
        private readonly ApplicationDbContext _context;
        public RelatorioController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var labels = new List<string>() { "January", "february", "March", "April", "May", "June", "July" };

            ViewBag.meses = labels;

            CarregarTotais();            
            return View();
        }

        private void CarregarTotais()
        {
            double totalValor = _context.Abastecimento.Sum(x => x.Litros * x.ValorLitro);
            int totalKm = SomaTotalKM();

            bool TemAbastecimentosRegistrados = _context.Abastecimento.Any();
            


            ViewBag.TotalValor = totalValor;
            ViewBag.TotalKM = totalKm;            
            ViewBag.CustoKM = (totalKm > 0) ? Math.Round(totalValor / totalKm, 2) : 0;

            ViewBag.CustoMes = TemAbastecimentosRegistrados ? CalcularCustoMensal() : 0;
        }

        private int SomaTotalKM()
        {
            bool TemAbastecimentosRegistrados = _context.Abastecimento.Any();
            int min = TemAbastecimentosRegistrados ? _context.Abastecimento.Min(x => x.Odometro) : 0;
            int max = TemAbastecimentosRegistrados ? _context.Abastecimento.Max(x => x.Odometro) : 0;
            return max - min;
        }

        private double CalcularCustoMensal()
        {
            var numeroMeses = ContarMesesComRegistros();
            var FirstMonth = DateTime.Now.AddMonths(NumeroMesesConsiderar * (-1));
            double totalValor = _context.Abastecimento
                .Where(x => x.Data >= FirstMonth)
                .Sum(x => x.Litros * x.ValorLitro);
            return (numeroMeses > 0) ? totalValor / numeroMeses : 0;
        }

        private int ContarMesesComRegistros()
        {
            var FirstMonth = DateTime.Now.AddMonths(NumeroMesesConsiderar * (-1));

            var primeiroAbastecimento = _context.Abastecimento.Where(x => x.Data >= FirstMonth).FirstOrDefault();

            if (primeiroAbastecimento == null)
            {
                return 0;
            }

            //útimos 12 meses por exemplo
            var now = DateTime.Now.AddDays(-1);
            var months = Enumerable.Range(NumeroMesesConsiderar * (-1), NumeroMesesConsiderar)
                .Select(x => new {
                    year = now.AddMonths(x).Year,
                    month = now.AddMonths(x).Month
                });

            var contadorMeses = 0;
            foreach (var month in months)
            {
                //abrir a aba saída e selecionar o AnotaCar vai ver esse json
                Console.WriteLine(JsonConvert.SerializeObject(month));

                if (month.year >= primeiroAbastecimento.Data.Year && month.month >= primeiroAbastecimento.Data.Month)
                {
                    contadorMeses++;
                }
                
            }

            return contadorMeses;
        }
    }
}
