﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OWAOP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GISIA2013Entities : DbContext
    {
        public GISIA2013Entities()
            : base("name=GISIA2013Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public DbSet<AlternativaCeldas> AlternativaCeldas { get; set; }
        public DbSet<AlternativaFilas> AlternativaFilas { get; set; }
        public DbSet<AlternativaILs> AlternativaILs { get; set; }
        public DbSet<AlternativaMatrizs> AlternativaMatrizs { get; set; }
        public DbSet<Alternativas> Alternativas { get; set; }
        public DbSet<ConjuntoEtiquetas> ConjuntoEtiquetas { get; set; }
        public DbSet<CriterioCeldas> CriterioCeldas { get; set; }
        public DbSet<CriterioFilas> CriterioFilas { get; set; }
        public DbSet<CriterioMatrizs> CriterioMatrizs { get; set; }
        public DbSet<Criterios> Criterios { get; set; }
        public DbSet<Etiquetas> Etiquetas { get; set; }
        public DbSet<Expertos> Expertos { get; set; }
        public DbSet<ExpertosEnProyecto> ExpertosEnProyecto { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<ValoracionAHPs> ValoracionAHPs { get; set; }
        public DbSet<ValoracionILs> ValoracionILs { get; set; }
        public DbSet<ValorCriterios> ValorCriterios { get; set; }
    }
}