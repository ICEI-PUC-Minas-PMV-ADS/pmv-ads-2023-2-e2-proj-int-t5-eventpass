using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventPass.Models;

namespace EventPass.Controllers
{
    public class GestorsController : Controller
    {
        private readonly AppDbContext _context;

        public GestorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Gestors
        public async Task<IActionResult> Index()
        {
              return View(await _context.Gestor.ToListAsync());
        }

        // GET: Gestors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gestor == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestor == null)
            {
                return NotFound();
            }

            return View(gestor);
        }

        // GET: Gestors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gestors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CNPJ,Email,Senha,ConfirmarSenha,Tipo")] Gestor gestor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gestor);
        }

        // GET: Gestors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gestor == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor.FindAsync(id);
            if (gestor == null)
            {
                return NotFound();
            }
            return View(gestor);
        }

        // POST: Gestors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CNPJ,Email,Senha,ConfirmarSenha,Tipo")] Gestor gestor)
        {
            if (id != gestor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestorExists(gestor.Id))
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
            return View(gestor);
        }

        // GET: Gestors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gestor == null)
            {
                return NotFound();
            }

            var gestor = await _context.Gestor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestor == null)
            {
                return NotFound();
            }

            return View(gestor);
        }

        // POST: Gestors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gestor == null)
            {
                return Problem("Entity set 'AppDbContext.Gestor'  is null.");
            }
            var gestor = await _context.Gestor.FindAsync(id);
            if (gestor != null)
            {
                _context.Gestor.Remove(gestor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestorExists(int id)
        {
          return _context.Gestor.Any(e => e.Id == id);
        }
    }
}
