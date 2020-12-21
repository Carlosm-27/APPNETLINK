using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_NETLINK.Models;
using APP_NETLINK.Controllers;


namespace APP_NETLINK.Filters
{
    public class VerifySession : ActionFilterAttribute
    {

        //sobreescritura de metodo, recibiendo un parametro con el tipo de datos 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //le pasamos la clase, anteriormente usig
            var varUser = (usuario)HttpContext.Current.Session["Usuario"];

            if (varUser == null)
            {

                //bloqueo de url
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/index");
                }

            }
            else
            {

                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/index");
                }

            }

            base.OnActionExecuting(filterContext);

        }

    }
}