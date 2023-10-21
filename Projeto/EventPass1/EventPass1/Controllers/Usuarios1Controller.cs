using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventPass1.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;


namespace EventPass1.Controllers
{

   
    public class Usuarios1Controller : Controller
    {
        private readonly AppDbContext _context;

        public Usuarios1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
      
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }
       
        public IActionResult AcessDenied()
        {
            return View();
        }

       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
       
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var dados = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);

            if (dados == null)
            {
                ViewBag.Message = "Usuário e/ou Senha inválidos! ";
                return View();
            }

            bool senhaok = BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha);

            if (senhaok)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, dados.NomeUsuario),
            new Claim(ClaimTypes.NameIdentifier, dados.Email.ToString()),
            new Claim(ClaimTypes.Role, dados.Tipo.ToString()),
        };

                var usuarioIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);
                return Redirect("/");
            }
            else
            {
                ViewBag.Message = "Usuário e/ou Senha inválidos! ";
            }

            return View();
        }
       
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


       

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Email == id);

            if (usuario == null)
            {
                return NotFound();
            }

            var userId = usuario.Id;

            ViewData["UserId"] = userId;

            return View(usuario);
        }



        // GET: Usuarios/Create

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,NomeUsuario,Email,Senha,ConfirmarSenha,CPF")] Usuario usuario)
        {
            var existingUserByEmail = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);
            var existingUserByCPF = await _context.Usuarios.FirstOrDefaultAsync(u => u.CPF == usuario.CPF);

            if (existingUserByEmail != null)
            {
                ModelState.AddModelError("Email", "O email já está em uso.");
            }

            if (existingUserByCPF != null)
            {
                ModelState.AddModelError("CPF", "O CPF ou CNPJ já está em uso.");
            }

            if (ModelState.IsValid)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                usuario.ConfirmarSenha = BCrypt.Net.BCrypt.HashPassword(usuario.ConfirmarSenha);
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(usuario);
        }


        // GET: Usuarios/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,NomeUsuario,Email,Senha,ConfirmarSenha,CPF")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    var usuarioOriginal = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
                    if (usuarioOriginal == null)
                    {
                        return NotFound();
                    }

                    
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    usuario.ConfirmarSenha = BCrypt.Net.BCrypt.HashPassword(usuario.ConfirmarSenha);
                    usuario.CPF = usuarioOriginal.CPF;                  

                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }


        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'AppDbContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Login));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
