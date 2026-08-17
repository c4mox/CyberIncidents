using AplicacionWeb.Filtros;
using AplicacionWeb.Models;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AplicacionWeb.Controllers
{
    public class InicioController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        [Logueado]
        public IActionResult Index() //Muestro la vista de inicio con el email y rol del usuario logueado
        {
            ViewBag.Email = HttpContext.Session.GetString("email");
            ViewBag.Rol = HttpContext.Session.GetString("rol");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Registro() //Muestro la vista de registro de un nuevo operador
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(
        string cedula,
        string nombre,
        string email,
        string telefono,
        string contrasenia) //Recibo los datos del formulario de registro de un nuevo operador y lo agrega al sistema
        {
            try
            {
                Persona operador = new Persona(
                    cedula,
                    nombre,
                    email,
                    telefono,
                    contrasenia,
                    Rol.OPERADOR
                );
                sistema.AgregarPersona(operador);
                HttpContext.Session.SetString("email", operador.Email);
                HttpContext.Session.SetString("rol", operador.Rol.ToString());
                return RedirectToAction("Index"); //Redirijo a la vista de inicio con el email y rol del usuario logueado
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public IActionResult Login(string mensaje) //Muestro la vista de login de operador o administrador
        {
            ViewBag.Error = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string contrasenia) //Recibo los datos del formulario de login
                                                                     //de operador o administrador y lo autentica en el sistema
        {
            try
            {
                Persona logueado = sistema.AutenticarPersona(email, contrasenia);
                HttpContext.Session.SetString("email", logueado.Email);
                HttpContext.Session.SetString("rol", logueado.Rol.ToString());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [Logueado]
        public IActionResult Perfil() //Muestro la vista de perfil del operador logueado con sus datos
        {
            string email = HttpContext.Session.GetString("email");

            Persona persona = sistema.BuscarPersonaPorEmail(email);

            return View(persona);
        }

        public IActionResult Logout() //Cierro la sesión del usuario logueado y redirige a la vista de login
        {
            HttpContext.Session.SetString("email", "");
            HttpContext.Session.SetString("rol", "");

            return RedirectToAction("Login");
        }
    }
}
