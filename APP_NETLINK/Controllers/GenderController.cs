using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_NETLINK.Models.TableViewModels;
using APP_NETLINK.Models.ViewModels;
using APP_NETLINK.Models;


namespace APP_NETLINK.Controllers
{
    public class GenderController : Controller
    {
        // GET: Gender
        public ActionResult Index()
        {

            List<GenderTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.genero
                       orderby data.Id_genero
                       select new GenderTableViewModel
                       {
                           id = data.Id_genero,
                           genero = data.nombre
                       }
                     ).ToList();
            }

            return View(lst);
        }


        [HttpPost]
        public ActionResult Insert(GenderTableViewModel model)
        {


            try
            {
                using (var data = new BD_NETLINKEntities1())
                {

                    genero objGender = new genero();
                    objGender.nombre = model.genero;
                    data.genero.Add(objGender);
                    data.SaveChanges();
                }
                Session["insert"] = "success";
                return View();
            }
            catch {
                Session["insert"] = "failed";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }



        public ActionResult Update(int id)
        {
            EditGenderViewModel objModelGen = new EditGenderViewModel();

            using (var data = new BD_NETLINKEntities1())
            {
                var oGen = data.genero.Find(id);
                objModelGen.genero = oGen.nombre;
            }

            return View(objModelGen);
        }


        [HttpPost]
        public ActionResult Update(EditGenderViewModel model)
        {


            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using (var data = new BD_NETLINKEntities1())
                {
                    var oGen = data.genero.Find(model.id);
                    oGen.nombre = model.genero;
                    data.Entry(oGen).State = System.Data.Entity.EntityState.Modified;
                    data.SaveChanges();
                }
                Session["update"] = "success";
                return View();
            }
            catch {
                Session["update"] = "failed";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {

                using (var data = new BD_NETLINKEntities1())
                {
                    var oGen = data.genero.Find(id);

                    data.genero.Remove(oGen);
                    data.SaveChanges();

                }               
                return Content("1");
            }
            catch {
                return Content("0");

            }
        }

    }
}