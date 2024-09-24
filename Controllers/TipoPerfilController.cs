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
    public class TipoPerfilController : Controller
    {
        private readonly Contexto _context;

        public TipoPerfilController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoPerfil
        public async Task<IActionResult> Index()
        {
              return _context.TipoPerfil != null ? 
                          View(await _context.TipoPerfil.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoPerfil'  is null.");
        }

        // GET: TipoPerfil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoPerfil == null)
            {
                return NotFound();
            }

            var tipoPerfil = await _context.TipoPerfil
                .FirstOrDefaultAsync(m => m.TipoPerfilId == id);
            if (tipoPerfil == null)
            {
                return NotFound();
            }

            return View(tipoPerfil);
        }

        // GET: TipoPerfil/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPerfil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoPerfilId,TipoPerfilNome")] TipoPerfil tipoPerfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPerfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPerfil);
        }

        // GET: TipoPerfil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoPerfil == null)
            {
                return NotFound();
            }

            var tipoPerfil = await _context.TipoPerfil.FindAsync(id);
            if (tipoPerfil == null)
            {
                return NotFound();
            }
            return View(tipoPerfil);
        }

        // POST: TipoPerfil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoPerfilId,TipoPerfilNome")] TipoPerfil tipoPerfil)
        {
            if (id != tipoPerfil.TipoPerfilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPerfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPerfilExists(tipoPerfil.TipoPerfilId))
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
            return View(tipoPerfil);
        }

        // GET: TipoPerfil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoPerfil == null)
            {
                return NotFound();
            }

            var tipoPerfil = await _context.TipoPerfil
                .FirstOrDefaultAsync(m => m.TipoPerfilId == id);
            if (tipoPerfil == null)
            {
                return NotFound();
            }

            return View(tipoPerfil);
        }

        // POST: TipoPerfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoPerfil == null)
            {
                return Problem("Entity set 'Contexto.TipoPerfil'  is null.");
            }
            var tipoPerfil = await _context.TipoPerfil.FindAsync(id);
            if (tipoPerfil != null)
            {
                _context.TipoPerfil.Remove(tipoPerfil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPerfilExists(int id)
        {
          return (_context.TipoPerfil?.Any(e => e.TipoPerfilId == id)).GetValueOrDefault();
        }
    }
}
