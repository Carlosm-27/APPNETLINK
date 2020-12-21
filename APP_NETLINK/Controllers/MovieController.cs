using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_NETLINK.Models;
using APP_NETLINK.Models.TableViewModels;
using APP_NETLINK.Models.ViewModels;


namespace APP_NETLINK.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {

            List<MovieTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.multimedia
                       where data.id_tipo_multimedia == 1
                       orderby data.enlace
                       select new MovieTableViewModel
                       {
                           enlace = data.enlace,
                           descripcion = data.descripcion,
                           titulo = data.Titulo,
                           id = data.Id_multimedia
                       }
                     ).ToList();
            }

            return View(lst);
        }


        [HttpPost]
        public ActionResult Insert(string title, string description, string link, int? director,int? gender,int? category, int? country, int? languaje, int? multimediaType, string titleCap)
        {

            using (var data = new BD_NETLINKEntities1())
            {

                try {
                    multimedia objMovie = new multimedia();
                    objMovie.Titulo = title;
                    objMovie.descripcion = description;
                    objMovie.enlace = link;

                    objMovie.Id_genero = gender;
                    objMovie.Id_Categoria = category;
                    objMovie.Id_director = director;

                    objMovie.Id_idioma = languaje;
                    objMovie.Id_pais = country;
                    objMovie.id_tipo_multimedia = 1;

                    data.multimedia.Add(objMovie);
                    data.SaveChanges();

                    //enviamos la consulta a otro datos


                    if (titleCap != "")
                    {
                        serie objSerie = new serie();
                        objSerie.capitulo = 1;
                        objSerie.id_multimedia = objMovie.Id_multimedia;
                        objSerie.titulo = titleCap;
                        data.serie.Add(objSerie);
                        data.SaveChanges();
                    }

                    Session["alert"] = "success";

                    return Content("true");
                }
                catch (Exception x) {
                    return Content("Se genero un error! " + x.Message);
                }
            }
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        public List<CountryTableViewModel> Country()
        {
            List<CountryTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.pais
                       orderby data.nombre
                       select new CountryTableViewModel
                       {
                           id = data.Id_pais,
                           pais = data.nombre
                       }
                     ).ToList();
            }

            return lst;
        }


        public List<LanguajeTableViewModel> Languaje()
        {
            List<LanguajeTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.Idioma
                       orderby data.nombre
                       select new LanguajeTableViewModel
                       {
                           id = data.Id_idioma,
                           idioma = data.nombre
                       }
                     ).ToList();
            }

            return lst;
        }



        public List<MultimediaTypeTableViewModel> MultimediaType()
        {
            List<MultimediaTypeTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.tipo_multimedia
                       orderby data.nombre
                       select new MultimediaTypeTableViewModel
                       {
                           id = data.id_tipo_multimedia,
                           tipo_multimedia = data.nombre
                       }
                     ).ToList();
            }

            return lst;
        }
        public ActionResult ShowMovie(int id)
        {
            MovieViewModel objModelM = new MovieViewModel();

            using (var data = new BD_NETLINKEntities1())
            {
                var oMov = data.multimedia.Find(id);
                objModelM.titulo = oMov.Titulo;
                objModelM.descripcion = oMov.descripcion;
                objModelM.enlace = oMov.enlace;

                objModelM.id_categoria = Convert.ToInt32(oMov.Id_Categoria);
                objModelM.id_genero = Convert.ToInt32(oMov.Id_genero);
                objModelM.id_director = Convert.ToInt32(oMov.Id_director);


                objModelM.id_idioma = Convert.ToInt32(oMov.Id_idioma);
                objModelM.id_pais = Convert.ToInt32(oMov.Id_pais);
                objModelM.id_tipo_multimedia = Convert.ToInt32(oMov.id_tipo_multimedia);

            }

            return View(objModelM);
        }





        public List<GenderTableViewModel> Gender()
        {
            List<GenderTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.genero
                       orderby data.nombre
                       select new GenderTableViewModel
                       {
                           id = data.Id_genero,
                           genero = data.nombre
                       }
                     ).ToList();
            }

            return lst;
        }


        public List<CategoryTableViewModel> Category()
        {
            List<CategoryTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.Categoria
                       orderby data.nombre
                       select new CategoryTableViewModel
                       {
                           id = data.Id_Categoria,
                           categoria = data.nombre
                       }
                     ).ToList();
            }

            return lst;
        }


        public List<DirectorTableViewModel> Director()
        {
            List<DirectorTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.director
                       orderby data.nombre
                       select new DirectorTableViewModel
                       {
                           id = data.Id_director,
                           director = data.nombre
                       }
                     ).ToList();
            }
            return lst;
        }



        public ActionResult BuscarPelicula()
        {
            return View();
        }



        public ActionResult Filter(int? gender, int? languaje, int? country, int? category)
        {

            List<MovieTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.multimedia
                       where 
                            data.Id_genero == gender && data.Id_Categoria == category
                                &&
                          data.Id_idioma == languaje && data.Id_pais == country
                       orderby data.Id_multimedia
                       select new MovieTableViewModel
                       {
                           enlace = data.enlace,
                           descripcion = data.descripcion,
                           titulo = data.Titulo,
                           id = data.Id_multimedia
                       }
                     ).ToList();
            }

            return View(lst);
        }






        public ActionResult ManagerMovie()
        {

            List<MovieTableViewModel> lst = null;
            using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
            {
                lst = (from data in bd.multimedia
                       orderby data.Id_multimedia
                       select new MovieTableViewModel
                       {
                           enlace = data.enlace,
                           descripcion = data.descripcion,
                           titulo = data.Titulo,
                           id = data.Id_multimedia
                       }
                     ).ToList();
            }

            return View(lst);
        }





        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {

                using (var data = new BD_NETLINKEntities1())
                {
                    var oGen = data.multimedia.Find(id);

                    data.multimedia.Remove(oGen);
                    data.SaveChanges();

                }
                return Content("1");
            }
            catch
            {
                return Content("0");

            }
        }


        public ActionResult Update(int id)
        {
            EditMovieViewModel objModelMov = new EditMovieViewModel();

            using (var data = new BD_NETLINKEntities1())
            {
                var oMov = data.multimedia.Find(id);
                objModelMov.descripcion = oMov.descripcion;
                objModelMov.enlace = oMov.enlace;
                objModelMov.id_categoria = Convert.ToInt32(oMov.Id_Categoria);
                objModelMov.id_director = Convert.ToInt32(oMov.Id_director);
                objModelMov.id_genero = Convert.ToInt32(oMov.Id_genero);
                objModelMov.id_idioma = Convert.ToInt32(oMov.Id_idioma);
                objModelMov.id_pais = Convert.ToInt32(oMov.Id_pais);
                objModelMov.id_tipo_multimedia = Convert.ToInt32(oMov.id_tipo_multimedia);
                objModelMov.titulo = oMov.Titulo;
                objModelMov.id = oMov.Id_multimedia;

            }

            return View(objModelMov);
        }


        [HttpPost]
        public ActionResult Update(string titulo, string descripcion, string enlace, int? director, int? gender, int? category, int? country, int? languaje, int? multimediaType, int? id)
        {

            try
            {

                using (var data = new BD_NETLINKEntities1())
                {
                    var objMovie = data.multimedia.Find(id);

                    objMovie.Titulo = titulo;
                    objMovie.descripcion = descripcion;
                    objMovie.enlace = enlace;

                    objMovie.Id_genero = gender;
                    objMovie.Id_Categoria = category;
                    objMovie.Id_director = director;

                    objMovie.Id_idioma = languaje;
                    objMovie.Id_pais = country;
                    objMovie.id_tipo_multimedia = multimediaType;

                    data.Entry(objMovie).State = System.Data.Entity.EntityState.Modified;
                    data.SaveChanges();
                    return Content("True");

                }
            }
            catch(Exception x)
            {
                return Content("Error" + x.Message);
            }

        }




    }
}