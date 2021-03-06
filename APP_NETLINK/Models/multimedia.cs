//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APP_NETLINK.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class multimedia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public multimedia()
        {
            this.PeliculasPorVer = new HashSet<PeliculasPorVer>();
            this.serie = new HashSet<serie>();
        }
    
        public int Id_multimedia { get; set; }
        public string Titulo { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> Id_genero { get; set; }
        public Nullable<int> Id_Categoria { get; set; }
        public Nullable<int> Id_director { get; set; }
        public Nullable<int> Id_idioma { get; set; }
        public Nullable<int> Id_pais { get; set; }
        public Nullable<int> id_tipo_multimedia { get; set; }
        public string enlace { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual director director { get; set; }
        public virtual genero genero { get; set; }
        public virtual Idioma Idioma { get; set; }
        public virtual pais pais { get; set; }
        public virtual tipo_multimedia tipo_multimedia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeliculasPorVer> PeliculasPorVer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<serie> serie { get; set; }
    }
}
