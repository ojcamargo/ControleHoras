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
    
    public partial class Profissional
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profissional()
        {
            this.Alocacao = new HashSet<Alocacao>();
            this.ProfissionalDispositivo = new HashSet<ProfissionalDispositivo>();
            this.Usuario = new HashSet<Usuario>();
            this.Lancamento = new HashSet<Lancamento>();
            this.HorasExtras = new HashSet<HorasExtras>();
        }
    
        public int ProfissionalID { get; set; }
        public string Nome { get; set; }
        public Nullable<System.TimeSpan> HorarioEntrada { get; set; }
        public Nullable<System.TimeSpan> HorarioSaida { get; set; }
        public Nullable<decimal> ValorHora { get; set; }
        public Nullable<decimal> ValorMensal { get; set; }
        public bool Ativo { get; set; }
        public string ModalidadeApuracao { get; set; }
        public string Regime { get; set; }
        public Nullable<System.DateTime> FeriasInicio { get; set; }
        public Nullable<System.DateTime> FeriasTermino { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alocacao> Alocacao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfissionalDispositivo> ProfissionalDispositivo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lancamento> Lancamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorasExtras> HorasExtras { get; set; }
    }
}
