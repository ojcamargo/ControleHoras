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
    
    public partial class ClienteLocal
    {
        public int LocalID { get; set; }
        public int ClienteID { get; set; }
        public string Logradouro { get; set; }
        public string NumeroLogradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}
