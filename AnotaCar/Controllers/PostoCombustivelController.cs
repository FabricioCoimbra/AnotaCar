using AnotaCar.Data;
using AnotaCar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AnotaCar.Controllers
{
    public class PostoCombustivelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostoCombustivelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostoCombustivel
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostoCombustivel.ToListAsync());
        }

        // GET: PostoCombustivel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postoCombustivel = await _context.PostoCombustivel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postoCombustivel == null)
            {
                return NotFound();
            }

            return View(postoCombustivel);
        }

        // GET: PostoCombustivel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostoCombustivel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Lat,Long")] PostoCombustivel postoCombustivel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postoCombustivel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postoCombustivel);
        }

        // GET: PostoCombustivel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postoCombustivel = await _context.PostoCombustivel.FindAsync(id);
            if (postoCombustivel == null)
            {
                return NotFound();
            }
            return View(postoCombustivel);
        }

        // POST: PostoCombustivel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Lat,Long")] PostoCombustivel postoCombustivel)
        {
            if (id != postoCombustivel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postoCombustivel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostoCombustivelExists(postoCombustivel.Id))
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
            return View(postoCombustivel);
        }

        // GET: PostoCombustivel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postoCombustivel = await _context.PostoCombustivel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postoCombustivel == null)
            {
                return NotFound();
            }

            return View(postoCombustivel);
        }

        // POST: PostoCombustivel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postoCombustivel = await _context.PostoCombustivel.FindAsync(id);
            _context.PostoCombustivel.Remove(postoCombustivel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostoCombustivelExists(int id)
        {
            return _context.PostoCombustivel.Any(e => e.Id == id);
        }
    }
}
