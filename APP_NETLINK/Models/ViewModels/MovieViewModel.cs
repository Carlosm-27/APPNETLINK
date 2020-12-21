using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APP_NETLINK.Models.ViewModels
{
    public class MovieViewModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Titulo")]
        public string titulo { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Enlace")]
        public string enlace { get; set; }

        //nuevos campos

        [Required]
        [Display(Name = "Género")]
        public int id_genero { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int id_categoria { get; set; }
        [Required]
        [Display(Name = "Director")]
        public int id_director { get; set; }

        [Required]
        [Display(Name = "Idioma")]
        public int id_idioma { get; set; }
        [Required]
        [Display(Name = "Pais")]
        public int id_pais { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public int id_tipo_multimedia { get; set; }


    }



    public class EditMovieViewModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Titulo")]
        public string titulo { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracter", MinimumLength = 1)]
        [Display(Name = "Enlace")]
        public string enlace { get; set; }

        //nuevos campos

        [Required]
        [Display(Name = "Género")]
        public int id_genero { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int id_categoria { get; set; }
        [Required]
        [Display(Name = "Director")]
        public int id_director { get; set; }

        [Required]
        [Display(Name = "Idioma")]
        public int id_idioma { get; set; }
        [Required]
        [Display(Name = "Pais")]
        public int id_pais { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public int id_tipo_multimedia { get; set; }

        public int id { get; set; }

    }
}