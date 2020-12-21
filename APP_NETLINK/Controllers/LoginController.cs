using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_NETLINK.Models;
using APP_NETLINK.Utils;


namespace APP_NETLINK.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Validar(string user, string pass)
        {

            try
            {

                pass = Encriptar.EncriptarClave(pass);

                using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
                {
                    var lista = from prg2 in bd.usuario
                                where prg2.email == user
                                   && prg2.password == pass
                                select prg2;

                    if (lista.Count() > 0)
                    {

                        usuario obj = lista.First();
                        Session["Usuario"] = obj;
                        Session["Validate"] = true;
                        Session["rol"] = obj.id_rol;
                        Session["usuario"] = obj.nombreUsuario;
                        Session["id_usuario"] = obj.Id_usuario;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario y contraseña invalido");
                    }
                }

            }
            catch (Exception x)
            {

                return Content("Se genero un error! " + x.Message);

            }
        }

        public ActionResult Logout()
        {

            Session["Usuario"] = null;
            Session["rol"] = null;
            Session["validate"] = null;
            Session["usuario"] = null;
            Session["id_usuario"] = null;


            return Redirect(Url.Content("~/Login/"));
        }

    }
}