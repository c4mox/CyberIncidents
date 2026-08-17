using AplicacionWeb.Filtros;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    [AdminFiltro]
    public class PersonaController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Index() //Muestro el listado de personas registradas en el sistema
        {
            return View(sistema.Personas);
        }
    }
}
