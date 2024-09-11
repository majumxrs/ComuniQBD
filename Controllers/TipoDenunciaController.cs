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
    public class TipoDenunciaController : Controller
    {
        private readonly Contexto _context;

        public TipoDenunciaController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoDenuncia
        public async Task<IActionResult> Index()
        {
              return _context.TipoDenuncia != null ? 
                          View(await _context.TipoDenuncia.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoDenuncia'  is null.");
        }

        // GET: TipoDenuncia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoDenuncia == null)
            {
                return NotFound();
            }

            var tipoDenuncia = await _context.TipoDenuncia
                .FirstOrDefaultAsync(m => m.TipoDenunciaId == id);
            if (tipoDenuncia == null)
            {
                return NotFound();
            }

            return View(tipoDenuncia);
        }

        // GET: TipoDenuncia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDenuncia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDenunciaId,TipoDenunciaNome")] TipoDenuncia tipoDenuncia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDenuncia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDenuncia);
        }

        // GET: TipoDenuncia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoDenuncia == null)
            {
                return NotFound();
            }

            var tipoDenuncia = await _context.TipoDenuncia.FindAsync(id);
            if (tipoDenuncia == null)
            {
                return NotFound();
            }
            return View(tipoDenuncia);
        }

        // POST: TipoDenuncia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDenunciaId,TipoDenunciaNome")] TipoDenuncia tipoDenuncia)
        {
            if (id != tipoDenuncia.TipoDenunciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDenuncia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDenunciaExists(tipoDenuncia.TipoDenunciaId))
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
            return View(tipoDenuncia);
        }

        // GET: TipoDenuncia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoDenuncia == null)
            {
                return NotFound();
            }

            var tipoDenuncia = await _context.TipoDenuncia
                .FirstOrDefaultAsync(m => m.TipoDenunciaId == id);
            if (tipoDenuncia == null)
            {
                return NotFound();
            }

            return View(tipoDenuncia);
        }

        // POST: TipoDenuncia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoDenuncia == null)
            {
                return Problem("Entity set 'Contexto.TipoDenuncia'  is null.");
            }
            var tipoDenuncia = await _context.TipoDenuncia.FindAsync(id);
            if (tipoDenuncia != null)
            {
                _context.TipoDenuncia.Remove(tipoDenuncia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDenunciaExists(int id)
        {
          return (_context.TipoDenuncia?.Any(e => e.TipoDenunciaId == id)).GetValueOrDefault();
        }
    }
}
