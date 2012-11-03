using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace sisexperto.Entidades
{
    public class GisiaExpertoContext : DbContext
    {
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Experto> Expertos { get; set; }

        public DbSet<Criterio> Criterios { get; set; }
        public DbSet<Alternativa> Alternativas { get; set; }

        public DbSet<ValoracionCriteriosPorExperto> ValoracionesCriteriosPorExpertos { get; set; }
        public DbSet<ValoracionAlternativasPorCriterioExperto> ValoracionesAlternativasPorCriterioExperto { get; set; }
        
        public DbSet<ComparacionCriterio> ComparacionCriterios { get; set; }
        public DbSet<ComparacionAlternativa> ComparacionAlternativas { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experto>()
                .HasMany(e => e.ProyectosAsignados)
                .WithMany(p => p.ExpertosAsignados)
                .Map(mp =>
                    {
                        mp.ToTable("ExpertosPorProyecto");
                        mp.MapLeftKey("ExpertoId");
                        mp.MapRightKey("ProyectoId");
                        
                    });
            base.OnModelCreating(modelBuilder);
        }
    }
}
