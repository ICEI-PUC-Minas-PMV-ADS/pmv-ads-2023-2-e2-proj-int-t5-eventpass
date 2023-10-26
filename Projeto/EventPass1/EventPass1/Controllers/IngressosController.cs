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
            return View(await _context.Ingressos.ToListAsync());
        }
        public IActionResult Reservar()

        {
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "IdEvento");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario");
            return View();
            
        }


        [HttpPost]
        public async Task<IActionResult> Reservar([Bind("IdEvento", "UsuarioId", "Quantidade")] Ingresso ingresso)
        {
           
            if (ModelState.IsValid)
            {
                _context.Ingressos.Add(ingresso);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "IdEvento", "IdEvento");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario", ingresso.UsuarioId);

            return View(ingresso);


            
        }


    }
}
