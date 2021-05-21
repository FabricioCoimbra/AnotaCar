using AnotaCar.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnotaCar.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RelatorioController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var labels = new List<string>() { "January", "february", "March", "April", "May", "June", "July" };

            ViewBag.meses = labels;
            ViewBag.TotalKM = "12";
            return View();
        }
    }
}
