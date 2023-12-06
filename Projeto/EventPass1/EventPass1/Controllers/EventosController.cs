
using EventPass1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection;

namespace EventPass1.Controllers
{
    public class EventosController : Controller
    {
        private readonly AppDbContext _context;

        public EventosController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var eventos = _context.Eventos

            .Include(i => i.Usuario)
            .Where(i => i.GestorId == userId)
            .ToList();

            ViewData["userId"] = userId;
            return View(eventos);
        }
        public IActionResult lista()
        {
            var eventos = _context.Eventos
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
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            ViewData["userId"] = userId;

            ViewData["GestorId"] = new SelectList(_context.Usuarios, "Id", "NomeUsuario");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEvento", "NomeEvento", "Data", "Hora", "TotalIngressos", "Descricao", "Local")] Evento evento, IFormFile flyer)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                evento.GestorId = userId;

                if (flyer != null && flyer.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + flyer.FileName;

                    var filePath = Path.Combine("wwwroot/flyer", uniqueFileName);
                    filePath = filePath.Replace("\\", "/");

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await flyer.CopyToAsync(fileStream);
                    }

                    evento.flyer = uniqueFileName;
                }

                _context.Eventos.Add(evento);
                await _context.SaveChangesAsync();

                for (int i = 1; i <= evento.TotalIngressos; i++)
                {
                    Ingresso ingresso = new Ingresso
                    {
                        IdEvento = evento.IdEvento,
                        IdUsuario = evento.GestorId,
                        Status = 0,
                        Quantidade = 0
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
        public async Task<IActionResult> Edit(int id, [Bind("IdEvento", "NomeEvento", "Data", "Hora", "TotalIngressos", "Descricao", "Local","flyer", "GestorId")] Evento evento, IFormFile flyer)
        {
            if (id != evento.IdEvento)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (flyer != null && flyer.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + flyer.FileName;

                    var filePath = Path.Combine("wwwroot/flyer", uniqueFileName);
                    filePath = filePath.Replace("\\", "/");

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await flyer.CopyToAsync(fileStream);
                    }

                    evento.flyer = uniqueFileName;
                }
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
        public async Task<IActionResult> Info(int? id)
        {
            if (id == null)
                return NotFound();

            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
                return NotFound();

            var ingresso = _context.Ingressos
                .Include(i => i.Evento)
                .Include(i => i.Usuario)
                .Where(i => i.IdEvento == id && i.Status == 0)
                .OrderBy(i => i.Id)
                .FirstOrDefault();

            var viewModel = new EventoIngressoViewModel
            {
                Evento = evento,
                Ingresso = ingresso // Aqui está associando o ingresso ao modelo EventoIngressoViewModel
            };

            return View(viewModel);
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

            var evento = await _context.Eventos
                .Include(e => e.Ingressos)
                .FirstOrDefaultAsync(e => e.IdEvento == id);

            if (evento == null)
            {
                return NotFound();
            }

            try
            {
                string relativePath = Path.Combine("wwwroot", "flyer", evento.flyer);

                string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;

                string completePath = Path.Combine(diretorioBase, relativePath);

                string parteIndesejada = Path.Combine("bin", "Debug", "net6.0");

                completePath = completePath.Replace(parteIndesejada, string.Empty);

                System.Diagnostics.Debug.WriteLine($"Caminho Completo: {completePath}");

                if (System.IO.File.Exists(completePath))
                {
                    System.IO.File.Delete(completePath);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno {ex.Message} ");
            }

            _context.Ingressos.RemoveRange(evento.Ingressos);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Buscar(string nomeEvento)
        {
            if (string.IsNullOrEmpty(nomeEvento))
            {
                return BadRequest("O nome do evento não pode ser vazio");
            }

            var evento = await _context.Eventos
                .Where(e => e.NomeEvento.Contains(nomeEvento))
                .FirstOrDefaultAsync();

            if (evento == null)
            {
                return NotFound("Evento não encontrado");
            }

            var ingressoDisponivel = await _context.Ingressos
                .Where(i => i.IdEvento == evento.IdEvento && i.Status == 0)
                .OrderBy(i => i.Id)
                .FirstAsync();

            if (ingressoDisponivel != null)
            {

                return View(ingressoDisponivel);
            }

            var ingressoEsgotado = await _context.Ingressos
                .Where(i => i.IdEvento == evento.IdEvento && i.Status == 1)
                .OrderBy(i => i.Id)
                .FirstOrDefaultAsync();

            if (ingressoEsgotado != null)
            {
                return Ok($"Ingressos esgotados para o evento. O ingresso disponível tem o Id {ingressoEsgotado.Id}.");
            }

            return NotFound("Nenhum ingresso disponível para o evento");
        }

    }
}



