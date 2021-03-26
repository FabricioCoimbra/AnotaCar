using AnotaCar.Data;
using AnotaCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnotaCar.Controllers
{
    public class AbastecimentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbastecimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Abastecimento
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Abastecimento.Include(a => a.Posto).Include(a => a.Veiculo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Abastecimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abastecimento = await _context.Abastecimento
                .Include(a => a.Posto)
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abastecimento == null)
            {
                return NotFound();
            }

            return View(abastecimento);
        }

        // GET: Abastecimento/Create
        public IActionResult Create()
        {
            ViewData["PostoId"] = new SelectList(_context.PostoCombustivel, "Id", "Nome");
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Modelo");
            return View();
        }

        // POST: Abastecimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostoId,Odometro,Litros,ValorLitro,TanqueCheio,VeiculoId,Observacao")] Abastecimento abastecimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abastecimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostoId"] = new SelectList(_context.PostoCombustivel, "Id", "Nome", abastecimento.PostoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Modelo", abastecimento.VeiculoId);
            return View(abastecimento);
        }

        // GET: Abastecimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abastecimento = await _context.Abastecimento.FindAsync(id);
            if (abastecimento == null)
            {
                return NotFound();
            }
            ViewData["PostoId"] = new SelectList(_context.PostoCombustivel, "Id", "Nome", abastecimento.PostoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Modelo", abastecimento.VeiculoId);
            return View(abastecimento);
        }

        // POST: Abastecimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostoId,Odometro,Litros,ValorLitro,TanqueCheio,VeiculoId,Observacao")] Abastecimento abastecimento)
        {
            if (id != abastecimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abastecimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbastecimentoExists(abastecimento.Id))
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
            ViewData["PostoId"] = new SelectList(_context.PostoCombustivel, "Id", "Nome", abastecimento.PostoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Modelo", abastecimento.VeiculoId);
            return View(abastecimento);
        }

        // GET: Abastecimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abastecimento = await _context.Abastecimento
                .Include(a => a.Posto)
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abastecimento == null)
            {
                return NotFound();
            }

            return View(abastecimento);
        }

        // POST: Abastecimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abastecimento = await _context.Abastecimento.FindAsync(id);
            _context.Abastecimento.Remove(abastecimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbastecimentoExists(int id)
        {
            return _context.Abastecimento.Any(e => e.Id == id);
        }
    }
}
