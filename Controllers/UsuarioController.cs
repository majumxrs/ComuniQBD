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
    public class UsuarioController : Controller
    {
        private readonly Contexto _context;

        public UsuarioController(Contexto context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var usuarios = _context.Usuario
                           .Include(g=> g.TipoPerfil);
            if (usuarios != null)
            {
                usuarios.ToListAsync().Wait();
                foreach (var item in usuarios)
                {
                    if(item.UsuarioFoto != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(inArray: item.UsuarioFoto);
                        string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                        item.ExibicaoImg = imageDataURL;
                    }                   
                }
                return View(usuarios);
            }
            else
            {
                return View();
            }
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.TipoPerfil)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["TipoPerfilId"] = new SelectList(_context.TipoPerfil, "TipoPerfilId", "TipoPerfilNome");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,UsuarioNome,UsuarioSobrenome,UsuarioApelido,UsuarioEmail,UsuarioTelefone,UsuarioCPF,UsuarioCEP,UsuarioCidade,UsuarioBairro,UsuarioEstado,UsuarioSenha,UsuarioFoto,TipoPerfilId")] Usuario usuario)
        {
            foreach (var file in Request.Form.Files)
            {

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                usuario.UsuarioFoto = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoPerfilId"] = new SelectList(_context.TipoPerfil, "TipoPerfilId", "TipoPerfilNome", usuario.TipoPerfilId);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["TipoPerfilId"] = new SelectList(_context.TipoPerfil, "TipoPerfilId", "TipoPerfilNome", usuario.TipoPerfilId);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,UsuarioNome,UsuarioSobrenome,UsuarioApelido,UsuarioEmail,UsuarioTelefone,UsuarioCPF,UsuarioCEP,UsuarioCidade,UsuarioBairro,UsuarioEstado,UsuarioSenha,UsuarioFoto,TipoPerfilId")] Usuario usuario)
        {
            foreach (var file in Request.Form.Files)
            {

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                usuario.UsuarioFoto = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioId))
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
            ViewData["TipoPerfilId"] = new SelectList(_context.TipoPerfil, "TipoPerfilId", "TipoPerfilNome", usuario.TipoPerfilId);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.TipoPerfil)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'Contexto.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        }
    }
}
