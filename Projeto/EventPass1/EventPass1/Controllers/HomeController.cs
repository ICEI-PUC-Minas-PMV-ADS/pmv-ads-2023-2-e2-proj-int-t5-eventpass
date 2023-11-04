using EventPass1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EventPass1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly AppDbContext _context;

		public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public IActionResult Pesquisar(string textoBusca)
		{
			if (!string.IsNullOrEmpty(textoBusca))
			{
				var resultado = _context.Eventos
				.Where(registro => registro.NomeEvento.Contains(textoBusca) ||
					   registro.Data.ToString().Contains(textoBusca))
				.ToList();

				if (resultado == null)
                    return NotFound();

				return View(resultado);
			}
			return View();
		}
	}
}