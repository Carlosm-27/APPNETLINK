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
    public class ShowMovieController : Controller
    {
        // GET: ShowMovie
        public ActionResult Index()
        {
            List<ShowMovieViewTableModel> lst = null;

            try
            {
                int id_usuario = Convert.ToInt32(Session["id_usuario"]);
                using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
                {
                    lst = (from data in bd.PeliculasPorVer
                           where data.Id_usuario == id_usuario
                           orderby data.Id_multimedia
                           select new ShowMovieViewTableModel
                           {
                               id_multimedia = data.Id_multimedia
                           }
                         ).ToList();
                }
                return View(lst);
            }
            catch(Exception x) {
                return Content("Error" + x.Message);
            }

        }




        public int Compare(int id_multimedia)
        {

            try
            {
                using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
                {
                    var lista = from prg2 in bd.PeliculasPorVer
                                where prg2.Id_multimedia == id_multimedia
                                && prg2.Id_usuario == Convert.ToInt32(Session["id_usuario"])
                                select prg2;

                    if (lista.Count() > 0)
                    {
                        PeliculasPorVer obj = lista.First();
                        return Convert.ToInt32(obj.Id_multimedia);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception x)
            {
                return 0;
            }
        }


        public List<MovieTableViewModel> Resultado(int? id_multimedia)
        {

            try
            {

                List<MovieTableViewModel> lst = null;
                using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
                {
                    lst = (from data in bd.multimedia
                           where data.Id_multimedia == Convert.ToInt32(id_multimedia)
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

                return lst;

            }
            catch (Exception x)
            {
                return null;
            }
        }




        public List<ShowMovieViewTableModel> ShowMovie(int? id_user)
        {


            List<ShowMovieViewTableModel> lst = null;

            try
            {
                using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
                {
                    lst = (from data in bd.PeliculasPorVer
                           where data.Id_usuario == id_user
                           orderby data.Id_multimedia
                           select new ShowMovieViewTableModel
                           {
                               id_multimedia = Convert.ToInt32(data.Id_multimedia)
                           }
                         ).ToList();
                }

                return lst;
            }
            catch {
                return lst;
            }
        }



        public List<MovieTableViewModel> ShowMovieFilter(int? id_multimedia)
        {

            List<MovieTableViewModel> lst = null;

            try
            {
                using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
                {
                    lst = (from data in bd.multimedia
                           where
                           data.Id_multimedia == id_multimedia
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

                return lst;
            }
            catch
            {
                return lst;
            }
        }


        [HttpPost]
        public ActionResult ShowMovieInsert(int? idPelicula)
        {

                try
                {
                    int id_usuario = 000;
                    id_usuario = Convert.ToInt32(Session["id_usuario"]);


                    using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
                    {
                        var lista = from prg2 in bd.PeliculasPorVer
                                    where prg2.Id_usuario == id_usuario
                                    && prg2.Id_multimedia == idPelicula
                                    select prg2;

                        if (lista.Count() > 0)
                        {

                            return Content("1");
                        }
                    }


                    using (var data = new BD_NETLINKEntities1())
                    {

                        PeliculasPorVer objSM = new PeliculasPorVer();
                        objSM.Id_multimedia = idPelicula;
                        objSM.Id_usuario = Convert.ToInt32(Session["id_usuario"]);
                        data.PeliculasPorVer.Add(objSM);
                        data.SaveChanges();
                        return Content("True");

                    }
                }
                catch (Exception x)
                {

                    return Content("Se genero un error! " + x.Message);

                }
        }






        [HttpPost]
        public ActionResult Delete(int id)
        {

            try
            {

                int id_usuario, id_PF = 0;
                id_usuario = Convert.ToInt32(Session["id_usuario"]);

                using (BD_NETLINKEntities1 bd = new BD_NETLINKEntities1())
                {
                    var lista = from prg2 in bd.PeliculasPorVer
                                where prg2.Id_multimedia == id
                                    && prg2.Id_usuario == id_usuario
                                select prg2;

                    if (lista.Count() > 0)
                    {

                        PeliculasPorVer obj = lista.First();
                        id_PF = Convert.ToInt32(obj.Id_peliculaPorVer);
                    }
                }

                using (var data = new BD_NETLINKEntities1())
                {
                    var oMovie = data.PeliculasPorVer.Find(id_PF);
                    data.PeliculasPorVer.Remove(oMovie);
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