using AplicacionWeb.Filtros;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    public class ActivoController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        [AdminFiltro] //Filtro que permite el acceso solo a administradores
        public IActionResult Index(int codigoCuenta, string error, string exito) //Muestra el listado de activos asociados a una cuenta.
        {
            ViewBag.Error = error;
            ViewBag.Exito = exito;
            ViewBag.CodigoCuenta = codigoCuenta;

            return View(sistema.ObtenerActivosDeCuenta(codigoCuenta));
        }

        [Logueado]
        public IActionResult VerActivos() //Muestra el listado de activos asociados al operador logueado
        {
            string email = HttpContext.Session.GetString("email");

            return View(sistema.ObtenerActivosOperador(email));
        }

        [AdminFiltro]
        public IActionResult Desasociar(string codigo) //Si no tiene incidentes asociados,
                                                       //desasocia el activo de la cuenta y redirige a la vista de activos
        {
            Activo activo = sistema.BuscarActivo(codigo);

            int codigoCuenta = activo.Cuenta.Codigo;

            if (sistema.TieneIncidentes(activo))
            {
                return RedirectToAction("Index",
                    new
                    {
                        codigoCuenta = codigoCuenta,
                        error = "No se puede desasociar porque tiene incidentes asociados" //muestra mensaje de errors
                    });
            }

            activo.Cuenta = null;

            return RedirectToAction("Index",
                new
                {
                    codigoCuenta = codigoCuenta,
                    exito = "Activo desasociado correctamente" //muestra mensaje de exito
                });
        }

        [AdminFiltro]
        public IActionResult Crear(int codigoCuenta) //Muestra la vista para crear un activo asociado a una cuenta
        {
            ViewBag.CodigoCuenta = codigoCuenta;

            return View();
        }

        [HttpPost] //Recibe los datos del formulario de creación de activo y lo agrega al sistema
        [AdminFiltro]
        public IActionResult Crear(
        int codigoCuenta,
        string nombre,
        TipoActivo tipoActivo,
        int criticidad,
        bool tieneBackup)
        {
            try
            {
                Cuenta cuenta = sistema.BuscarCuenta(codigoCuenta); //lLama al método BuscarCuenta de la clase Sistema
                                                                    //para obtener la cuenta correspondiente

                Activo activo = new Activo(
                    nombre,
                    tipoActivo,
                    criticidad,
                    cuenta,
                    tieneBackup
                );

                sistema.AgregarActivo(activo);

                return RedirectToAction("Index",
                    new { codigoCuenta = codigoCuenta });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.CodigoCuenta = codigoCuenta;

                return View();
            }
        }
    }
}