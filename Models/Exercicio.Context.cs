﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exercicio.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExercicioLabEntities : DbContext
    {
        public ExercicioLabEntities()
            : base("name=ExercicioLabEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ator> Ator { get; set; }
        public virtual DbSet<Atuacao> Atuacao { get; set; }
        public virtual DbSet<Diretor> Diretor { get; set; }
        public virtual DbSet<Documentario> Documentario { get; set; }
        public virtual DbSet<Filme> Filme { get; set; }
        public virtual DbSet<LongaMetragem> LongaMetragem { get; set; }
        public virtual DbSet<Produtor> Produtor { get; set; }
    }
}
