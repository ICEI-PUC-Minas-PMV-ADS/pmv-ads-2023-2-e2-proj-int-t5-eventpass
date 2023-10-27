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
            var ingressos = await _context.Ingressos
            .Include(i => i.Evento)
            .Include(i => i.Usuario)
            .ToListAsync();

            return View(ingressos);
        }
        public IActionResult Reservar()

        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "IdUsuario");
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> Reservar([Bind("IdEvento","IdUsuario","Quantidade")] Ingresso ingresso)
        {
            if (ModelState.IsValid)
            {
                
                
                _context.Ingressos.Add(ingresso);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario", ingresso.IdUsuario);


            return View(ingresso);
        }
    }
}
