using EventPass1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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


    }
}
