//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControleHoras.DATA.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProfissionalDispositivo
    {
        public int ProfissionalDispositivoID { get; set; }
        public int ProfissionalID { get; set; }
        public string Imei { get; set; }
        public string Telefone { get; set; }
    
        public virtual Profissional Profissional { get; set; }
    }
}