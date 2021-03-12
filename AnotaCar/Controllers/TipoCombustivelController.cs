using AnotaCar.Data;
using AnotaCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnotaCar.Controllers
{
    public class TipoCombustivelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoCombustivelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoCombustivel
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoCombustivel.ToListAsync());
        }

        // GET: TipoCombustivel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCombustivel = await _context.TipoCombustivel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCombustivel == null)
            {
                return NotFound();
            }

            return View(tipoCombustivel);
        }

        // GET: TipoCombustivel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCombustivel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] TipoCombustivel tipoCombustivel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCombustivel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCombustivel);
        }

        // GET: TipoCombustivel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCombustivel = await _context.TipoCombustivel.FindAsync(id);
            if (tipoCombustivel == null)
            {
                return NotFound();
            }
            return View(tipoCombustivel);
        }

        // POST: TipoCombustivel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] TipoCombustivel tipoCombustivel)
        {
            if (id != tipoCombustivel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCombustivel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCombustivelExists(tipoCombustivel.Id))
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
            return View(tipoCombustivel);
        }

        // GET: TipoCombustivel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCombustivel = await _context.TipoCombustivel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCombustivel == null)
            {
                return NotFound();
            }

            return View(tipoCombustivel);
        }

        // POST: TipoCombustivel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoCombustivel = await _context.TipoCombustivel.FindAsync(id);
            _context.TipoCombustivel.Remove(tipoCombustivel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCombustivelExists(int id)
        {
            return _context.TipoCombustivel.Any(e => e.Id == id);
        }
    }
}
