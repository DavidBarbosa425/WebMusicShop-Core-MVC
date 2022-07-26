using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using WebMusicShop.Models.Entities;
using WebMusicShop.Models.Enums;

namespace WebMusicShop.Filters
{
    public class PaginaRestritaSomenteAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                Usuario? usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if (usuario.Perfil != Perfil.Administrador.ToString())
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller","Restrito" }, {"action","Index" } });
                    
                }
            }
            base.OnActionExecuted(context);
        }

    }
}
