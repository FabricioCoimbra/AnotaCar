using AnotaCar.Data;
using AnotaCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnotaCar.Controllers
{
    public class ServicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Servico
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Servico.Include(s => s.TipoServico).Include(s => s.Veiculo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Servico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico
                .Include(s => s.TipoServico)
                .Include(s => s.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // GET: Servico/Create
        public IActionResult Create()
        {
            ViewData["TipoServicoId"] = new SelectList(_context.TipoServico, "Id", "Descricao");
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Modelo");
            return View();
        }

        // POST: Servico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoServicoId,Valor,Data,VeiculoId,Odometro,Observacao")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoServicoId"] = new SelectList(_context.TipoServico, "Id", "Descricao", servico.TipoServicoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Modelo", servico.VeiculoId);
            return View(servico);
        }

        // GET: Servico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            ViewData["TipoServicoId"] = new SelectList(_context.TipoServico, "Id", "Descricao", servico.TipoServicoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Modelo", servico.VeiculoId);
            return View(servico);
        }

        // POST: Servico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoServicoId,Valor,Data,VeiculoId,Odometro,Observacao")] Servico servico)
        {
            if (id != servico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.Id))
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
            ViewData["TipoServicoId"] = new SelectList(_context.TipoServico, "Id", "Descricao", servico.TipoServicoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculo, "Id", "Modelo", servico.VeiculoId);
            return View(servico);
        }

        // GET: Servico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico
                .Include(s => s.TipoServico)
                .Include(s => s.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // POST: Servico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servico = await _context.Servico.FindAsync(id);
            _context.Servico.Remove(servico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicoExists(int id)
        {
            return _context.Servico.Any(e => e.Id == id);
        }
    }
}
