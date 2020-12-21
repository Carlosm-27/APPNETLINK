using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_NETLINK.Models;
using APP_NETLINK.Models.TableViewModels;
using APP_NETLINK.Models.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;
using APP_NETLINK.Utils;


namespace APP_NETLINK.Controllers
{
    public class UserController : Controller
    {

        //MarkaDaataEntities context
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.usuario
                       where data.id_rol == 2
                       orderby data.email
                       select new UserTableViewModel
                       {
                           id = data.Id_usuario,
                           email = data.email,
                           password = data.password,
                           nombreUsuario = data.nombreUsuario,
                           nombre = data.nombre,
                           apellido = data.apellido
                       }
                     ).ToList();
            }

            return View(lst);

        }


        [HttpPost]
        public ActionResult Insert(UserTableViewModel model)
        {

            try
            {


                if (model.password != model.confPassword)
                {
                    Session["insert"] = "failedPassword";
                    return View();
                }

                using (var data = new BD_NETLINKEntities1())
                {


                    usuario objUser = new usuario();
                    objUser.id_rol = 2;
                    objUser.email = model.email;
                    objUser.password = Encriptar.EncriptarClave(model.password);
                    objUser.nombre = model.nombre;
                    objUser.apellido = model.apellido;
                    objUser.telefono = model.telefono;
                    objUser.nombreUsuario = model.nombreUsuario;

                    data.usuario.Add(objUser);
                    data.SaveChanges();
               }
                Session["insert"] = "success";
                return View();
            }
            catch
            {
                Session["insert"] = "failed";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }


        //agregar vista
        public ActionResult Update(int id)
        {
            EditUserViewModel objModelUser = new EditUserViewModel();

            using (var data = new BD_NETLINKEntities1())
            {
                var oUser = data.usuario.Find(id);
                objModelUser.email = oUser.email;
                //objModelUser.password = oUser.password;
                objModelUser.id = oUser.Id_usuario;
                objModelUser.nombre = oUser.nombre;
                objModelUser.apellido = oUser.apellido;
                objModelUser.telefono = oUser.telefono;
                objModelUser.nombreUsuario = oUser.nombreUsuario;
            }

            return View(objModelUser);
        }


        [HttpPost]
        public ActionResult Update(string nombreUsuario, int telefono, string nombre, string apellido, string email, string password, string confPassword, int id)
        {

            try
            {
                if (Convert.ToInt32(Session["id_usuario"]) != id && Convert.ToInt32(Session["rol"]) != 1) {
                    return Content("Failed");
                }

                if (password != confPassword)
                {
                    return Content("Failed");
                }

                using (var data = new BD_NETLINKEntities1())
                {
                    var oUser = data.usuario.Find(id);
                    oUser.email = email;
                    //oUser.password = Encriptar.EncriptarClave(password);
                    oUser.nombre = nombre;
                    oUser.apellido = apellido;
                    oUser.telefono = telefono;
                    oUser.nombreUsuario = nombreUsuario;




                    if (password != null && password.Trim() != "")
                    {
                        oUser.password = Encriptar.EncriptarClave(password);
                    }

                    data.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    data.SaveChanges();
                }
                return Content("True");
            }
            catch {
                return Content("Failed");
            }

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            try {
                using (var data = new BD_NETLINKEntities1())
                {
                    var oUser = data.usuario.Find(id);
                    /*data.Entry(oUser).State = System.Data.Entity.EntityState.Modified;

                    data.(oUser);
                    data.SaveChanges();
                    data.SaveChanges();

                    var query = (from p in data.Categoria
                                    where p.Id_Categoria == id
                                    select p).Single();*/

                    data.usuario.Remove(oUser);
                    data.SaveChanges();

                }
                return Content("1");
            }
            catch
            {
                return Content("0");
            }

        }

    }
}