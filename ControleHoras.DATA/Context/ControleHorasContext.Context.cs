﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alocacao> Alocacao { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ClienteIp> ClienteIp { get; set; }
        public virtual DbSet<ClienteLocal> ClienteLocal { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Lancamento> Lancamento { get; set; }
        public virtual DbSet<Profissional> Profissional { get; set; }
        public virtual DbSet<ProfissionalDispositivo> ProfissionalDispositivo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<HorasExtras> HorasExtrasSet { get; set; }
    }
}
