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
            new Claim(ClaimTypes.NameIdentifier, dados.Id.ToString()),
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


        public async Task<IActionResult> Details(int id)
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

            var userId = usuario.Id;

            ViewData["UserId"] = userId;

            return View(usuario);
        }

    
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
        public IActionResult EsqueciSenha()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EsqueciSenha(string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                // Trate o caso em que o e-mail não está registrado no sistema.
                ViewBag.Message = "E-mail não encontrado.";
                return View();
            }

            // Gere um token de redefinição de senha (por exemplo, um GUID).
            string token = Guid.NewGuid().ToString();

            // Armazene o token no banco de dados associado ao usuário.
            usuario.TokenRedefinicaoSenha = token;
            _context.Update(usuario);
            await _context.SaveChangesAsync();

            // Envie um e-mail ao usuário com um link para redefinir a senha, incluindo o token no link.
            // Implemente a lógica de envio de e-mail aqui.

            ViewBag.Message = "Um link para redefinir sua senha foi enviado para o seu e-mail.";
            return View();
        }
        public IActionResult RedefinirSenha(string token)
        {
            // Verifique se o token é válido e se existe no banco de dados.
            var usuario = _context.Usuarios.FirstOrDefault(u => u.TokenRedefinicaoSenha == token);

            if (usuario == null)
            {
                // Trate o caso em que o token não é válido.
                ViewBag.Message = "Token de redefinição de senha inválido.";
                return View("EsqueciMinhaSenha");
            }

            ViewBag.Token = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RedefinirSenha(string token, string novaSenha)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.TokenRedefinicaoSenha == token);

            if (usuario == null)
            {
                // Trate o caso em que o token não é válido.
                ViewBag.Message = "Token de redefinição de senha inválido.";
                return View();
            }

            // Atualize a senha do usuário com a nova senha.
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(novaSenha);
            usuario.TokenRedefinicaoSenha = null; // Limpe o token de redefinição de senha.

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            ViewBag.Message = "Senha redefinida com sucesso. Agora você pode fazer login com a nova senha.";
            return View();
        }


    }
}
