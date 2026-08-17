using AplicacionWeb.Filtros;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    [AdminFiltro]
    public class IncidenteController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Index() //Muestro el listado de incidentes agrupados por severidad
        {
            return View(sistema.ObtenerIncidentesPorSeveridad());
        }
    }
}
