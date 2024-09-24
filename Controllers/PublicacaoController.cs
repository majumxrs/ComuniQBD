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
    public class PublicacaoController : Controller
    {
        private readonly Contexto _context;

        public PublicacaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Publicacao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Publicacao.Include(p => p.Bairro);
            return View(await contexto.ToListAsync());
        }

        // GET: Publicacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Publicacao == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacao
                .Include(p => p.Bairro)
                .FirstOrDefaultAsync(m => m.PublicacaoId == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        // GET: Publicacao/Create
        public IActionResult Create()
        {
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "BairroId");
            return View();
        }

        // POST: Publicacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublicacaoId,PublicacaoTitulo,BairroId,PublicacaoMidia,PublicacaoDescricao")] Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                //Adicionando a publicação no banco            
                _context.Add(publicacao);
                await _context.SaveChangesAsync();

                // Criado o objeto PublicacaoUsuario para inserir na tabela auxiliar o id do usuario e da publicação
                var usuariopubli = new PublicacaoUsuario();
                usuariopubli.UsuarioId = 1;
                usuariopubli.PublicacaoId = publicacao.PublicacaoId;
                _context.Add(usuariopubli);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "BairroId", publicacao.BairroId);
            return View(publicacao);
        }

        // GET: Publicacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Publicacao == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacao.FindAsync(id);
            if (publicacao == null)
            {
                return NotFound();
            }
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "BairroId", publicacao.BairroId);
            return View(publicacao);
        }

        // POST: Publicacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PublicacaoId,PublicacaoTitulo,BairroId,PublicacaoMidia,PublicacaoDescricao")] Publicacao publicacao)
        {
            if (id != publicacao.PublicacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacaoExists(publicacao.PublicacaoId))
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
            ViewData["BairroId"] = new SelectList(_context.Bairro, "BairroId", "BairroId", publicacao.BairroId);
            return View(publicacao);
        }

        // GET: Publicacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Publicacao == null)
            {
                return NotFound();
            }

            var publicacao = await _context.Publicacao
                .Include(p => p.Bairro)
                .FirstOrDefaultAsync(m => m.PublicacaoId == id);
            if (publicacao == null)
            {
                return NotFound();
            }

            return View(publicacao);
        }

        // POST: Publicacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Publicacao == null)
            {
                return Problem("Entity set 'Contexto.Publicacao'  is null.");
            }
            var publicacao = await _context.Publicacao.FindAsync(id);
            if (publicacao != null)
            {
                _context.Publicacao.Remove(publicacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacaoExists(int id)
        {
          return (_context.Publicacao?.Any(e => e.PublicacaoId == id)).GetValueOrDefault();
        }
    }
}
