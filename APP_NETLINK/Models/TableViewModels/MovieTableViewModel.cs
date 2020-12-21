using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_NETLINK.Models.TableViewModels
{
    public class MovieTableViewModel
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string enlace { get; set; }
        public int id_genero { get; set; }


        public int id_categoria { get; set; }
        public int id_director { get; set; }
        public int id_idioma { get; set; }
        public int id_pais { get; set; }
        public int id_tipo_multimedia { get; set; }
    }
}