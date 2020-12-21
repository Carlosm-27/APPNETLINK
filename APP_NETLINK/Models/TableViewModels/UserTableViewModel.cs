using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_NETLINK.Models.TableViewModels
{
    public class UserTableViewModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confPassword { get; set; }
        public string nombreUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int telefono { get; set; }
        public int id_rol { get; set; }

    }
}