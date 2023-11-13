using Bank.Models;
using Bank.Repositories;
using Bank.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Bank.Controllers
{    
    public class ClienteController : Controller
    {

        private IClienteCollection db = new ClienteCollection();
 

        public async Task<IActionResult> Index(string id)
        {            
            Cliente document = await db.Get(id);

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
        public async Task<IActionResult> Insert(Cliente entidad)
        {
            if (entidad == null)
                return BadRequest();

            await db.Insert(entidad);

            return Created("Creado", true);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Cliente entidad, string _id)
        {
            if (entidad == null)
                return BadRequest();

            entidad.Id = new ObjectId(_id);           

            await db.Update(entidad);

            return RedirectToAction("Index", new { id = _id });

        }

    }
}
