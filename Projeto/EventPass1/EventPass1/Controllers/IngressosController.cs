using EventPass1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventPass1.Controllers
{

    public class IngressosController : Controller
    {
        private readonly AppDbContext _context;

        public IngressosController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var ingressos = _context.Ingressos
            .Include(i => i.Evento)
            .Include(i => i.Usuario);


            return View(await ingressos.ToListAsync());
        }
        public IActionResult Reservar()

        {
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NomeEvento");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario");
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> Reservar([Bind("IdEvento, IdUsuario, Quantidade")] Ingresso ingresso)
        {
            if (ModelState.IsValid)
            {

                int ingressosReservados = _context.Ingressos
     .Where(i => i.IdEvento == ingresso.IdEvento && i.IdUsuario == ingresso.IdUsuario)
     .Sum(i => i.Quantidade);


                if (ingressosReservados + ingresso.Quantidade <= 3)
                {

                    _context.Ingressos.Add(ingresso);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Você já atingiu o limite de 3 ingressos para este evento.");
                }
            }

            ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "IdEvento", ingresso.IdEvento);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "IdUsuario", ingresso.IdUsuario);

            return View(ingresso);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ingressos == null)
                return NotFound();

            var ingresso = await _context.Ingressos.FindAsync(id);

            if (ingresso == null)
                return NotFound();

            return View(ingresso);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, IdEvento, IdUsuario, Quantidade")] Ingresso ingresso)
        {
            if (id != ingresso.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingIngresso = await _context.Ingressos.FindAsync(id);

                if (existingIngresso == null)
                    return NotFound();

                int ingressosReservados = _context.Ingressos
                    .Where(i => i.IdEvento == ingresso.IdEvento && i.IdUsuario == ingresso.IdUsuario && i.Id != id)
                    .Sum(i => i.Quantidade);

                if (ingressosReservados + ingresso.Quantidade <= 3)
                {
                    existingIngresso.IdEvento = ingresso.IdEvento;
                    existingIngresso.IdUsuario = ingresso.IdUsuario;
                    existingIngresso.Quantidade = ingresso.Quantidade;

                    _context.Ingressos.Update(existingIngresso);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Você já atingiu o limite de 3 ingressos para este evento.");
                }
            }

            return View(ingresso);
        }


        private bool IngressoExists(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ingressos == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingressos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ingressos == null)
            {
                return Problem("Entity set 'AppDbContext.Ingressos'  is null.");
            }
            var ingresso = await _context.Ingressos.FindAsync(id);
            if (ingresso != null)
            {
                _context.Ingressos.Remove(ingresso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
