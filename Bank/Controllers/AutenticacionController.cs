using Bank.Models;
using Bank.Repositories;
using Bank.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{    
    public class AutenticacionController : Controller
    {

        private IAutenticacionCollection db = new AutenticacionCollection();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetOne(string usuario, string contrasena)
        {
            var document = await db.GetAutenticacion(usuario, contrasena);

            if (document!=null)
            {
                //Guardo la session del usuario logueado
                HttpContext.Session.SetString("IdCliente", document.Id.ToString());

                return RedirectToAction("Index", "Cliente", new { id = document.Id });
            }
            else
            {
                return BadRequest();
            }            
        }

        public async Task<IActionResult> Insert([FromBody] Autenticacion autenticacion)
        {
            if (autenticacion == null)
                return BadRequest();

            await db.InsertUsuario(autenticacion);

            return Created("Creado", true);

        }

    }
}
