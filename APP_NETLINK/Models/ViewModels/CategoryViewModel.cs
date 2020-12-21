using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APP_NETLINK.Models.ViewModels
{
    public class CategoryViewModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Categoria")]
        public string categoria { get; set; }
    }


    public class EditCategoryViewModel
    {

        public int id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Categoria")]
        public string categoria { get; set; }
    }
}