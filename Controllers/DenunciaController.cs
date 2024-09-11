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
    public class DenunciaController : Controller
    {
        private readonly Contexto _context;

        public DenunciaController(Contexto context)
        {
            _context = context;
        }

        // GET: Denuncia
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Denuncia.Include(d => d.Bairro).Include(d => d.TipoDenuncia);
            return View(await contexto.ToListAsync());
        }

        // GET: Denuncia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Denuncia == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncia
                .Include(d => d.Bairro)
                .Include(d => d.TipoDenuncia)
                .FirstOrDefaultAsync(m => m.DenunciaId == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // GET: Denuncia/Create
        public IActionResult Create()
        {
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "BairroNome");
            ViewData["TipoDenunciaId"] = new SelectList(_context.TipoDenuncia, "TipoDenunciaId", "TipoDenunciaNome");
            return View();
        }

        // POST: Denuncia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DenunciaId,DenunciaTitulo,DenunciaMidia,DenunciaDescricao,TipoDenunciaId,BairroId")] Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denuncia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "BairroNome", denuncia.BairroId);
            ViewData["TipoDenunciaId"] = new SelectList(_context.TipoDenuncia, "TipoDenunciaId", "TipoDenunciaNome", denuncia.TipoDenunciaId);
            return View(denuncia);
        }

        // GET: Denuncia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Denuncia == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncia.FindAsync(id);
            if (denuncia == null)
            {
                return NotFound();
            }
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "BairroNome", denuncia.BairroId);
            ViewData["TipoDenunciaId"] = new SelectList(_context.TipoDenuncia, "TipoDenunciaId", "TipoDenunciaNome", denuncia.TipoDenunciaId);
            return View(denuncia);
        }

        // POST: Denuncia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DenunciaId,DenunciaTitulo,DenunciaMidia,DenunciaDescricao,TipoDenunciaId,BairroId")] Denuncia denuncia)
        {
            if (id != denuncia.DenunciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denuncia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenunciaExists(denuncia.DenunciaId))
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
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "BairroNome", denuncia.BairroId);
            ViewData["TipoDenunciaId"] = new SelectList(_context.TipoDenuncia, "TipoDenunciaId", "TipoDenunciaNome", denuncia.TipoDenunciaId);
            return View(denuncia);
        }

        // GET: Denuncia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Denuncia == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncia
                .Include(d => d.Bairro)
                .Include(d => d.TipoDenuncia)
                .FirstOrDefaultAsync(m => m.DenunciaId == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // POST: Denuncia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Denuncia == null)
            {
                return Problem("Entity set 'Contexto.Denuncia'  is null.");
            }
            var denuncia = await _context.Denuncia.FindAsync(id);
            if (denuncia != null)
            {
                _context.Denuncia.Remove(denuncia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenunciaExists(int id)
        {
          return (_context.Denuncia?.Any(e => e.DenunciaId == id)).GetValueOrDefault();
        }
    }
}
