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
    
    public partial class PeliculasPorVer
    {
        public int Id_peliculaPorVer { get; set; }
        public Nullable<int> Id_usuario { get; set; }
        public Nullable<int> Id_multimedia { get; set; }
    
        public virtual multimedia multimedia { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual usuario usuario1 { get; set; }
    }
}
