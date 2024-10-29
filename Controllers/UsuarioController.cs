using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComuniQBD.Models;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.DeviceFarm.Model;
using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using ComuniQBD.Services;

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
        public async Task<IActionResult> Index(string pesquisa)
        {      
            if (pesquisa == null)
            {
                var usuarios = _context.Usuario
                          .Include(g => g.TipoPerfil);
                return View(await usuarios.ToListAsync() );
            }
            else
            {
                var usuarios = _context.Usuario
                         .Include(g => g.TipoPerfil)
                         .Where(x => x.UsuarioNome
                         .Contains(pesquisa))
                         .OrderBy(x => x.UsuarioNome);               
                
                return View(await usuarios.ToListAsync() );
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
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
            }
            if (Request.Form.Files.Count > 0)
            {
                var s3 = new AWS_Service();
                await s3.UploadObject( Request, usuario.UsuarioCPF, "usuario" );
                usuario.UsuarioFoto = "usuario_" + usuario.UsuarioCPF + ".jpg";
            }

            if (usuario.UsuarioId > 0 )
            {
                _context.Update(usuario);
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
            if (Request.Form.Files.Count > 0)
            {
                var s3 = new AWS_Service();
                await s3.UploadObject(Request, usuario.UsuarioCPF , "usuario" );
                usuario.UsuarioFoto = "usuario_" + usuario.UsuarioCPF + ".jpg";
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
                if (usuario.UsuarioFoto != null)
                {
                    var s3 = new AWS_Service();
                    await s3.DeleteObject(usuario.UsuarioFoto);
                }
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Pesquisa(string pesquisa)
        {
            if (pesquisa == null)
            {
                return _context.Usuario != null ?
                          View(await _context.Usuario.ToListAsync()) :
                          Problem("Entity set 'Contexto.Usuario'  is null.");
            }
            else
            {
                var usuario =
                    _context.Usuario
                    .Where(x => x.UsuarioNome.Contains(pesquisa))
                    .OrderBy(x => x.UsuarioNome);

                return View(usuario);
            }
        }

    }
}
