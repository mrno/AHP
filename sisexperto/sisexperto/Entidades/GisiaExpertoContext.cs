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

        public DbSet<ValoracionCriteriosPorExperto> ValoracionesCriteriosPorExpertos { get; set; }
        public DbSet<ValoracionAlternativasPorCriterioExperto> ValoracionesAlternativasPorCriterioExperto { get; set; }
        
        public DbSet<ComparacionCriterio> ComparacionCriterios { get; set; }
        public DbSet<ComparacionAlternativa> ComparacionAlternativas { get; set; }


        public DbSet<Etiqueta> Etiqueta { get; set; }
        public DbSet<ConjuntoEtiquetas> ConjuntoEtiquetas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            /*
            modelBuilder.Entity<Proyecto>()
                .HasRequired(x => x.Creador)
                .WithMany(b => b.ProyectosCreados)
                .HasForeignKey(x => x.CreadorId).WillCascadeOnDelete(false);*/
            base.OnModelCreating(modelBuilder);
        }

       

    }
}
