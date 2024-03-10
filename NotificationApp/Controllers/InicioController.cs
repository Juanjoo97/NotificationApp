using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationApp.Data;
using NotificationApp.Models;
using System.Diagnostics;

namespace NotificationApp.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public InicioController(ApplicationDbContext contexto)
        {
           _contexto= contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Produccion.ToListAsync());
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id== null)
            {
                return NotFound();
            }
            var produccion = _contexto.Produccion.Find(id);
            if (produccion == null)
            {
                return NotFound();
            }
            return View(produccion);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Produccion produccion)
        {
            if(ModelState.IsValid)
            {
                _contexto.Update(produccion);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produccion = _contexto.Produccion.Find(id);
            if (produccion == null)
            {
                return NotFound();
            }
            return View(produccion);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produccion = _contexto.Produccion.Find(id);
            if (produccion == null)
            {
                return NotFound();
            }
            return View(produccion);
        }
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarProduccion(int? id)
        {
            var produccion = await _contexto.Produccion.FindAsync(id);
            if(produccion == null)
            {  
                return View();
            }
            _contexto.Produccion.Remove(produccion);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
