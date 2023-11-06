﻿
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
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var eventos = _context.Eventos
                
                .Include(i => i.Usuario)
                .Where(i => i.GestorId == userId)
                .ToList();

            return View(eventos);
        }

 

        public async Task<IActionResult> Relatorio(int id)
        {
            var dados = await _context.Eventos.FindAsync(id);

            if (dados == null)
                return NotFound();

            var reservados = _context.Ingressos
                .Where(i => i.IdEvento == id && i.Status == 1)
                .Count();

            var disponiveis = _context.Ingressos
                .Where(i => i.IdEvento == id && i.Status == 0)
                .Count();
            
            double percent = ((double)reservados / dados.TotalIngressos) * 100;
            
            ViewBag.Reservados = reservados;
            ViewBag.Disponiveis = disponiveis;
            ViewBag.Percentual = percent;

            return View(dados);
        }

        public IActionResult Create()
        {
            ViewData["GestorId"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEvento", "NomeEvento", "Data", "Hora", "TotalIngressos", "Descricao", "Local")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                
                evento.GestorId = userId;

                _context.Eventos.Add(evento);
                await _context.SaveChangesAsync();


                for (int i = 1; i <= evento.TotalIngressos; i++)
                {
                    Ingresso ingresso = new Ingresso
                    {
                        IdEvento = evento.IdEvento,
                        IdUsuario = evento.GestorId,
                        Status = 0,
                    };
                    _context.Ingressos.Add(ingresso);
                }

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



