
using EventPass1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventPass1.Controllers
{


    public class EventosController : Controller
    {
        private readonly AppDbContext _context;
        public EventosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Eventos.Include(c => c.Usuarios);
            return View(await appDbContext.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["GestorId"] = new SelectList(_context.Usuarios, "Id", "CPF");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEvento", "NomeEvento", "Data","Hora", "TotalIngressos","Descricao","Local", "GestorId")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                _context.Eventos.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GestorId"] = new SelectList(_context.Usuarios, "Id", "CPF", evento.GestorId);

            return View(evento);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
                return NotFound();

            ViewData["GestorId"] = new SelectList(_context.Usuarios, "Id", "CPF", evento.GestorId);

            return View(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdEvento", "NomeEvento", "Data","Hora", "TotalIngressos","Descricao","Local", "GestorId")] Evento evento)
        {
            if (id != evento.IdEvento)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Eventos.Update(evento);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewData["GestorId"] = new SelectList(_context.Usuarios, "Id", "CPF", evento.GestorId);

            return View(evento);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Eventos.FindAsync(id);

            if (dados == null)
                return NotFound();

            ViewBag.Evento = dados;

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Eventos.FindAsync(id);

            if (dados == null)
                return NotFound();

            ViewBag.Evento = dados;

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Eventos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Eventos.Remove(dados);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}



