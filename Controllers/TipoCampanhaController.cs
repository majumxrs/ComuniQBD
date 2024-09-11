using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComuniQBD.Models;

namespace ComuniQBD.Controllers
{
    public class TipoCampanhaController : Controller
    {
        private readonly Contexto _context;

        public TipoCampanhaController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoCampanha
        public async Task<IActionResult> Index()
        {
              return _context.TipoCampanha != null ? 
                          View(await _context.TipoCampanha.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoCampanha'  is null.");
        }

        // GET: TipoCampanha/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoCampanha == null)
            {
                return NotFound();
            }

            var tipoCampanha = await _context.TipoCampanha
                .FirstOrDefaultAsync(m => m.TipoCampanhaId == id);
            if (tipoCampanha == null)
            {
                return NotFound();
            }

            return View(tipoCampanha);
        }

        // GET: TipoCampanha/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCampanha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoCampanhaId,TipoCampanhaNome")] TipoCampanha tipoCampanha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCampanha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCampanha);
        }

        // GET: TipoCampanha/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoCampanha == null)
            {
                return NotFound();
            }

            var tipoCampanha = await _context.TipoCampanha.FindAsync(id);
            if (tipoCampanha == null)
            {
                return NotFound();
            }
            return View(tipoCampanha);
        }

        // POST: TipoCampanha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoCampanhaId,TipoCampanhaNome")] TipoCampanha tipoCampanha)
        {
            if (id != tipoCampanha.TipoCampanhaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCampanha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCampanhaExists(tipoCampanha.TipoCampanhaId))
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
            return View(tipoCampanha);
        }

        // GET: TipoCampanha/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoCampanha == null)
            {
                return NotFound();
            }

            var tipoCampanha = await _context.TipoCampanha
                .FirstOrDefaultAsync(m => m.TipoCampanhaId == id);
            if (tipoCampanha == null)
            {
                return NotFound();
            }

            return View(tipoCampanha);
        }

        // POST: TipoCampanha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoCampanha == null)
            {
                return Problem("Entity set 'Contexto.TipoCampanha'  is null.");
            }
            var tipoCampanha = await _context.TipoCampanha.FindAsync(id);
            if (tipoCampanha != null)
            {
                _context.TipoCampanha.Remove(tipoCampanha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCampanhaExists(int id)
        {
          return (_context.TipoCampanha?.Any(e => e.TipoCampanhaId == id)).GetValueOrDefault();
        }
    }
}
