using AnotaCar.Data;
using AnotaCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnotaCar.Controllers
{
    public class TipoVeiculoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoVeiculoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoVeiculo
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoVeiculo.ToListAsync());
        }

        // GET: TipoVeiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVeiculo = await _context.TipoVeiculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoVeiculo == null)
            {
                return NotFound();
            }

            return View(tipoVeiculo);
        }

        // GET: TipoVeiculo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoVeiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] TipoVeiculo tipoVeiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoVeiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoVeiculo);
        }

        // GET: TipoVeiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVeiculo = await _context.TipoVeiculo.FindAsync(id);
            if (tipoVeiculo == null)
            {
                return NotFound();
            }
            return View(tipoVeiculo);
        }

        // POST: TipoVeiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] TipoVeiculo tipoVeiculo)
        {
            if (id != tipoVeiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoVeiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoVeiculoExists(tipoVeiculo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoVeiculo);
        }

        // GET: TipoVeiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVeiculo = await _context.TipoVeiculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoVeiculo == null)
            {
                return NotFound();
            }

            return View(tipoVeiculo);
        }

        // POST: TipoVeiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoVeiculo = await _context.TipoVeiculo.FindAsync(id);
            _context.TipoVeiculo.Remove(tipoVeiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoVeiculoExists(int id)
        {
            return _context.TipoVeiculo.Any(e => e.Id == id);
        }
    }
}
