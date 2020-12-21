using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace APP_NETLINK.Models.ViewModels
{
    public class UserViewModel
    {
        //public int? id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Correo Electronico")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme Password")]
        [Compare("Password", ErrorMessage = "Los password no son iguales")]
        public string confPassword { get; set; }


        //nuevos campos

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public int telefono { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Nombre de usuario")]
        public string nombreUsuario { get; set; }


        public int? id_rol { get; set; }

    }



    public class EditUserViewModel
    {
        public int id { get; set; }

        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Correo Electronico")]
        public string email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme Password")]
        [Compare("Password", ErrorMessage = "Los password no son iguales")]
        public string confPassword { get; set; }


        //nuevos campos
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        /*[StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [DataType(DataType.PhoneNumber)]*/
        [Display(Name = "Telefono")]
        public int? telefono { get; set; }

        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Nombre de usuario")]
        public string nombreUsuario { get; set; }

        public int? id_rol { get; set; }
    }
}