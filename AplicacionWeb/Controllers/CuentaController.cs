using AplicacionWeb.Filtros;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWeb.Controllers
{
    [AdminFiltro]
    public class CuentaController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Index(string cedula) //Muestro el listado de cuentas asociadas a una persona
        {
            ViewBag.Cedula = cedula;

            return View(sistema.ObtenerCuentasDePersona(cedula)); //llamo al metodo ObtenerCuentasDePersona de la clase Sistema
                                                                  //para obtener las cuentas asociadas a la persona
        }
        public IActionResult Crear(string cedula) //Muestro la vista para crear una cuenta asociada a una persona
        {
            ViewBag.Cedula = cedula;

            return View();
        }
        [HttpPost]
        public IActionResult Crear(string cedula, bool mfaHabilitado, DateTime fechaUltCambioPass) //Recibo los datos del formulario de
                                                                                                   //creación de cuenta y lo agrega al sistema
        {
            try
            {
                Persona titular = sistema.BuscarPersonaPorCedula(cedula);

                Cuenta cuenta = new Cuenta(
                    titular,
                    mfaHabilitado,
                    fechaUltCambioPass
                );

                sistema.AgregarCuenta(cuenta);

                return RedirectToAction("Index",
                    new { cedula = cedula }); //Redirigo a la vista de listado de cuentas asociadas a la persona
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Cedula = cedula;

                return View();
            }
        }
    }
}
