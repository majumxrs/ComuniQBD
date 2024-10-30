using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComuniQBD.Models;
using ComuniQBD.Services;

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
            var campanhas = _context.Campanha.Include(g => g.TipoCampanha).Include(g => g.Cidade).Include(c => c.Usuario);
            if (campanhas != null)
            {                
                return View(await campanhas.ToListAsync());
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
                .Include(c => c.Usuario)
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome");
            return View();
        }

        // POST: Campanha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CampanhaId,CampanhaTitulo,CampanhaMidia,CampanhaDescricao,TipoCampanhaId,CidadeId, UsuarioId")] Campanha campanha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campanha);
                await _context.SaveChangesAsync();
            }
            if (Request.Form.Files.Count > 0)
            {
                var s3 = new AWS_Service();
                await s3.UploadObject(Request, campanha.CampanhaId.ToString(), "campanha");
                campanha.CampanhaMidia = "campanha_" + campanha.CampanhaId + ".jpg";
            }

            if (campanha.CampanhaId > 0)
            {
                _context.Update(campanha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", campanha.CidadeId);
            ViewData["TipoCampanhaId"] = new SelectList(_context.TipoCampanha, "TipoCampanhaId", "TipoCampanhaNome", campanha.TipoCampanhaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", campanha.UsuarioId);
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", campanha.UsuarioId);
            return View(campanha);
        }

        // POST: Campanha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CampanhaId,CampanhaTitulo,CampanhaMidia,CampanhaDescricao,TipoCampanhaId,CidadeId, UsuarioId")] Campanha campanha)
        {
            
            if (id != campanha.CampanhaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        var s3 = new AWS_Service();
                        if(campanha.CampanhaMidia != "")
                        {
                            await s3.DeleteObject(campanha.CampanhaMidia);
                        }
                        await s3.UploadObject(Request, campanha.CampanhaId.ToString(), "campanha");
                        campanha.CampanhaMidia = "campanha_" + campanha.CampanhaId + ".jpg";
                    }
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", campanha.UsuarioId);
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
                .Include(c => c.Usuario)
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

                if (campanha.CampanhaMidia != null)
                {
                    var s3 = new AWS_Service();
                    await s3.DeleteObject(campanha.CampanhaMidia);
                }
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
