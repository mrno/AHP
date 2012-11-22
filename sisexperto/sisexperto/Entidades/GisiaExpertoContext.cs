using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using sisexperto.Entidades;

namespace sisExperto.Entidades
{
    public class GisiaExpertoContext : DbContext
    {

        public GisiaExpertoContext() : base("DataContext") { }

        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Experto> Expertos { get; set; }
        public DbSet<ExpertoEnProyecto> ExpertosEnProyectos { get; set; }

        public DbSet<Criterio> Criterios { get; set; }
        public DbSet<Alternativa> Alternativas { get; set; }

        public DbSet<CriterioMatriz> CriteriosMatrices { get; set; }
        public DbSet<CriterioFila> CriteriosFilas { get; set; }
        public DbSet<CriterioCelda> CriteriosCeldas { get; set; }


        public DbSet<AlternativaMatriz> AlternativasMatrices { get; set; }
        public DbSet<AlternativaFila> AlternativasFilas { get; set; }
        public DbSet<AlternativaCelda> AlternativasCeldas { get; set; }


        public DbSet<Etiqueta> Etiqueta { get; set; }
        public DbSet<ConjuntoEtiquetas> ConjuntoEtiquetas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
            modelBuilder.Entity<Proyecto>()
                .HasRequired(x => x.Creador)
                .WithMany(b => b.ProyectosCreados)
                .HasForeignKey(x => x.CreadorId).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<CriterioMatriz>()                
                .HasRequired(x => x.ExpertoEnProyecto)                
                .WithRequiredDependent(x => x.CriterioMatriz);
            

            base.OnModelCreating(modelBuilder);
        }

       

    }
}
