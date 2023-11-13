using Bank.Models;
using Bank.Repositories;
using Bank.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Bank.Controllers
{
    public class HistorialController : Controller
    {

        private IHistorialCollection db = new HistorialCollection();

        public async Task<IActionResult> Index(string CuentaOrigen)
        {
            ViewData["IdCliente"] = HttpContext.Session.GetString("IdCliente");
            List<Historial> document = await db.Get(CuentaOrigen);

            if (document!=null)
            {
                return View(document);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Historial entidad)
        {
            if (entidad == null)
                return BadRequest();

            await db.Insert(entidad);

            return Created("Creado", true);

        }

    }
}
