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
    public class BairroController : Controller
    {
        private readonly Contexto _context;

        public BairroController(Contexto context)
        {
            _context = context;
        }

        // GET: Bairro
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Bairro.Include(b => b.Cidade).Include(b => b.Estado);
            return View(await contexto.ToListAsync());
        }

        // GET: Bairro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bairro == null)
            {
                return NotFound();
            }

            var bairro = await _context.Bairro
                .Include(b => b.Cidade)
                .Include(b => b.Estado)
                .FirstOrDefaultAsync(m => m.BairroId == id);
            if (bairro == null)
            {
                return NotFound();
            }

            return View(bairro);
        }

        // GET: Bairro/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeId");
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "EstadoId");
            return View();
        }

        // POST: Bairro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BairroId,BairroNome,CidadeId,EstadoId")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bairro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeId", bairro.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "EstadoId", bairro.EstadoId);
            return View(bairro);
        }

        // GET: Bairro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bairro == null)
            {
                return NotFound();
            }

            var bairro = await _context.Bairro.FindAsync(id);
            if (bairro == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeId", bairro.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "EstadoId", bairro.EstadoId);
            return View(bairro);
        }

        // POST: Bairro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BairroId,BairroNome,CidadeId,EstadoId")] Bairro bairro)
        {
            if (id != bairro.BairroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bairro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BairroExists(bairro.BairroId))
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
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeId", bairro.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "EstadoId", bairro.EstadoId);
            return View(bairro);
        }

        // GET: Bairro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bairro == null)
            {
                return NotFound();
            }

            var bairro = await _context.Bairro
                .Include(b => b.Cidade)
                .Include(b => b.Estado)
                .FirstOrDefaultAsync(m => m.BairroId == id);
            if (bairro == null)
            {
                return NotFound();
            }

            return View(bairro);
        }

        // POST: Bairro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bairro == null)
            {
                return Problem("Entity set 'Contexto.Bairro'  is null.");
            }
            var bairro = await _context.Bairro.FindAsync(id);
            if (bairro != null)
            {
                _context.Bairro.Remove(bairro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BairroExists(int id)
        {
          return (_context.Bairro?.Any(e => e.BairroId == id)).GetValueOrDefault();
        }
    }
}
