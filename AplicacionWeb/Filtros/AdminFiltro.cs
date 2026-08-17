using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AplicacionWeb.Filtros
{
    public class AdminFiltro : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)  //Sobrescribo el método OnActionExecuting para verificar
                                                                                //si el usuario tiene rol de administrador antes de ejecutar la acción del controlador
        {
            string rol = context.HttpContext.Session.GetString("rol");

            if (string.IsNullOrEmpty(rol) || rol != "ADMIN")
            {
                context.Result = new RedirectToActionResult("Login", "Inicio",
                    new { mensaje = "Acceso restringido" });
            }

            base.OnActionExecuting(context);
        }
    }
}
