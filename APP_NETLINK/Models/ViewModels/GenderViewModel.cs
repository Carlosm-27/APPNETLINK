using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APP_NETLINK.Models.ViewModels
{
    public class GenderViewModel
    {
        public int id_genero { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Género")]
        public string genero { get; set; }

    }

    public class EditGenderViewModel
    {

        public int id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Género")]
        public string genero { get; set; }

    }
}