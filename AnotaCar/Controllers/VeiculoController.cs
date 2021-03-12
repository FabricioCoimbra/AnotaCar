using AnotaCar.Data;
using AnotaCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnotaCar.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeiculoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Veiculo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Veiculo.Include(v => v.Marca).Include(v => v.TipoVeiculo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Veiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .Include(v => v.Marca)
                .Include(v => v.TipoVeiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // GET: Veiculo/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Descricao");
            ViewData["TipoVeiculoID"] = new SelectList(_context.TipoVeiculo, "Id", "Descricao");
            return View();
        }

        // POST: Veiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Modelo,Ano,Placa,CapacidadeTanque,TipoVeiculoID,MarcaId")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Descricao", veiculo.MarcaId);
            ViewData["TipoVeiculoID"] = new SelectList(_context.TipoVeiculo, "Id", "Descricao", veiculo.TipoVeiculoID);
            return View(veiculo);
        }

        // GET: Veiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Descricao", veiculo.MarcaId);
            ViewData["TipoVeiculoID"] = new SelectList(_context.TipoVeiculo, "Id", "Descricao", veiculo.TipoVeiculoID);
            return View(veiculo);
        }

        // POST: Veiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Modelo,Ano,Placa,CapacidadeTanque,TipoVeiculoID,MarcaId")] Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(veiculo.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Descricao", veiculo.MarcaId);
            ViewData["TipoVeiculoID"] = new SelectList(_context.TipoVeiculo, "Id", "Descricao", veiculo.TipoVeiculoID);
            return View(veiculo);
        }

        // GET: Veiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .Include(v => v.Marca)
                .Include(v => v.TipoVeiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // POST: Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);
            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(int id)
        {
            return _context.Veiculo.Any(e => e.Id == id);
        }
    }
}
