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
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {

            try {
                List<CategoryTableViewModel> lst = null;
                using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
                {
                    lst = (from data in bd.Categoria
                           orderby data.Id_Categoria
                           select new CategoryTableViewModel
                           {
                               id = data.Id_Categoria,
                               categoria = data.nombre
                           }
                         ).ToList();
                }

                return View(lst);

            }
            catch (Exception x) {

                return Content("Ocurrio un error" + x);
            
            }

        }

        public List<CategoryTableViewModel> ShowCategory()
        {

            List<CategoryTableViewModel> lst = null;

            try
            {
                using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
                {
                    lst = (from data in bd.Categoria
                           orderby data.Id_Categoria
                           select new CategoryTableViewModel
                           {
                               id = data.Id_Categoria,
                               categoria = data.nombre
                           }
                         ).ToList();
                }

                return lst.ToList();

            }
            catch{

                return lst.ToList();
            }
        }




        [HttpPost]
        public ActionResult Insert(CategoryTableViewModel model)
        {
            try
            {
                using (var data = new BD_NETLINKEntities1())
                {

                    Categoria objUser = new Categoria();
                    objUser.nombre = model.categoria;
                    data.Categoria.Add(objUser);
                    data.SaveChanges();
                    Session["insert"] = "success";
                    return View();
                }

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

            try
            {
                EditCategoryViewModel objModelCat = new EditCategoryViewModel();

                using (var data = new BD_NETLINKEntities1())
                {
                    var oCat = data.Categoria.Find(id);
                    objModelCat.categoria = oCat.nombre;
                }

                return View(objModelCat);
            }
            catch (Exception x)
            {

                return Content("Ocurrio un error" + x);

            }

        }


        [HttpPost]
        public ActionResult Update(EditCategoryViewModel model)
        {


            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using (var data = new BD_NETLINKEntities1())
                {
                    var oCat = data.Categoria.Find(model.id);
                    oCat.nombre = model.categoria;
                    data.Entry(oCat).State = System.Data.Entity.EntityState.Modified;
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
                    var oCat = data.Categoria.Find(id);


                    data.Categoria.Remove(oCat);
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