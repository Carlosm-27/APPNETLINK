using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APP_NETLINK.Models.ViewModels
{
    public class DirectorViewModel
    {


        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "director")]
        public string director { get; set; }
    }
}