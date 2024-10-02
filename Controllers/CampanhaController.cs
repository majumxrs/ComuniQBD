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
    public class CampanhaController : Controller
    {
        private readonly Contexto _context;

        public CampanhaController(Contexto context)
        {
            _context = context;
        }

        // GET: Campanha
        public async Task<IActionResult> Index()
        {
            var campanhas = _context.Campanha.Include(g=> g.TipoCampanha).Include(g=> g.Cidade);
            if (campanhas != null)
            {
                campanhas.ToListAsync().Wait();
                foreach (var item in campanhas)
                {
                    if (item.CampanhaMidia != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(inArray: item.CampanhaMidia);
                        string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                        item.ExibicaoImg = imageDataURL;
                    }                    
                }
                return View(campanhas);
            }
            else
            {
                return View();
            }
        }

        // GET: Campanha/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Campanha == null)
            {
                return NotFound();
            }

            var campanha = await _context.Campanha
                .Include(c => c.Cidade)
                .Include(c => c.TipoCampanha)
                .FirstOrDefaultAsync(m => m.CampanhaId == id);
            if (campanha == null)
            {
                return NotFound();
            }

            return View(campanha);
        }

        // GET: Campanha/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome");
            ViewData["TipoCampanhaId"] = new SelectList(_context.TipoCampanha, "TipoCampanhaId", "TipoCampanhaNome");
            return View();
        }

        // POST: Campanha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CampanhaId,CampanhaTitulo,CampanhaMidia,CampanhaDescricao,TipoCampanhaId,CidadeId")] Campanha campanha)
        {
            foreach (var file in Request.Form.Files)
            {

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                campanha.CampanhaMidia = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }
            if (ModelState.IsValid)
            {
                _context.Add(campanha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", campanha.CidadeId);
            ViewData["TipoCampanhaId"] = new SelectList(_context.TipoCampanha, "TipoCampanhaId", "TipoCampanhaNome", campanha.TipoCampanhaId);
            return View(campanha);
        }

        // GET: Campanha/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Campanha == null)
            {
                return NotFound();
            }

            var campanha = await _context.Campanha.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", campanha.CidadeId);
            ViewData["TipoCampanhaId"] = new SelectList(_context.TipoCampanha, "TipoCampanhaId", "TipoCampanhaNome", campanha.TipoCampanhaId);
            return View(campanha);
        }

        // POST: Campanha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CampanhaId,CampanhaTitulo,CampanhaMidia,CampanhaDescricao,TipoCampanhaId,CidadeId")] Campanha campanha)
        {
            foreach (var file in Request.Form.Files)
            {

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                campanha.CampanhaMidia = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }
            if (id != campanha.CampanhaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campanha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampanhaExists(campanha.CampanhaId))
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
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", campanha.CidadeId);
            ViewData["TipoCampanhaId"] = new SelectList(_context.TipoCampanha, "TipoCampanhaId", "TipoCampanhaNome", campanha.TipoCampanhaId);
            return View(campanha);
        }

        // GET: Campanha/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Campanha == null)
            {
                return NotFound();
            }

            var campanha = await _context.Campanha
                .Include(c => c.Cidade)
                .Include(c => c.TipoCampanha)
                .FirstOrDefaultAsync(m => m.CampanhaId == id);
            if (campanha == null)
            {
                return NotFound();
            }

            return View(campanha);
        }

        // POST: Campanha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Campanha == null)
            {
                return Problem("Entity set 'Contexto.Campanha'  is null.");
            }
            var campanha = await _context.Campanha.FindAsync(id);
            if (campanha != null)
            {
                _context.Campanha.Remove(campanha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampanhaExists(int id)
        {
          return (_context.Campanha?.Any(e => e.CampanhaId == id)).GetValueOrDefault();
        }
    }
}
