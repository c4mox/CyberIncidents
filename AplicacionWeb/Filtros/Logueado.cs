using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AplicacionWeb.Filtros
{
    public class Logueado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string email = context.HttpContext.Session.GetString("email");

            if (string.IsNullOrEmpty(email))
            {
                context.Result = new RedirectToActionResult("Login", "Inicio",
                    new { mensaje = "Inicie sesión" }); //Si no hay un email en la sesión, redirige a la vista de login con un mensaje de error
            }

            base.OnActionExecuting(context);
        }
    }
}
