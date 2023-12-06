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
        private readonly EmailService _emailService;
        private readonly AppDbContext _context;

        public IngressosController(EmailService emailService, AppDbContext context)
        {
            _emailService = emailService;
            _context = context;
        }
        public IActionResult Index()
        {
            var ingressos = _context.Ingressos
                .Include(i => i.Evento)
                .Include(i => i.Usuario)
                .Where(i => i.Status == 0)
                .GroupBy(i => i.IdEvento)
                .Select(group => group.OrderBy(i => i.Id).First())
                .ToList();

            return View(ingressos);
        }
        public IActionResult MeusIngressos()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var ingressos1 = _context.Ingressos
            .Include(i => i.Evento)
            .Include(i => i.Usuario)
            .Where(i => i.IdUsuario == userId && i.Status != 0)
            .ToList();

            ViewData["userId"] = userId;

            return View(ingressos1);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ingressos == null)
                return NotFound();

            var ingresso = await _context.Ingressos.FindAsync(id);

            if (ingresso == null)
                return NotFound();
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "NomeEvento");


            return View(ingresso);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "IdEvento")] Ingresso ingresso)
        {
            if (id != ingresso.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingIngresso = await _context.Ingressos.FindAsync(id);

                if (existingIngresso == null)
                    return NotFound();

                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                int limiteIngressos = 3;


                int QuantidadeExistente = _context.Ingressos
                    .Where(i => i.IdEvento == ingresso.IdEvento && i.IdUsuario == userId && i.Id != id && i.Status != 0)
                    .Sum(i => i.Quantidade);

                if (QuantidadeExistente < limiteIngressos)
                {
                    existingIngresso.IdEvento = ingresso.IdEvento;
                    existingIngresso.IdUsuario = userId;
                    existingIngresso.Status = 1;
                    existingIngresso.Quantidade = 1;

                    _context.Ingressos.Update(existingIngresso);
                    await _context.SaveChangesAsync();

                    var evento = _context.Eventos.Find(ingresso.IdEvento);
                    var usuario = _context.Usuarios.Find(userId);


                    _emailService.EnviarEmailConfirmacaoReserva(usuario.Email, ingresso.Id, evento.NomeEvento, usuario.NomeUsuario);

                    return RedirectToAction("MeusIngressos");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Você já atingiu o limite de " + limiteIngressos + " ingressos para este evento.");
                }
            }

            return View(ingresso);
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
                ingresso.Status = 0;
                ingresso.Quantidade = 0;
                _context.Ingressos.Update(ingresso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("MeusIngressos");
        }

    }
}
