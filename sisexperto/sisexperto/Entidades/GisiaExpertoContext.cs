

using System.Data.Entity;
using sisexperto.Entidades;
using sisexperto.Entidades.AHP;


namespace sisExperto.Entidades
{
    public class GisiaExpertoContext : DbContext
    {
        public GisiaExpertoContext() : base("DataContext")
        {
            
        }

        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Experto> Expertos { get; set; }
        public DbSet<ExpertoEnProyecto> ExpertosEnProyectos { get; set; }

        public DbSet<Criterio> Criterios { get; set; }
        public DbSet<Alternativa> Alternativas { get; set; }

        public DbSet<ValoracionAHP> ValoracionesAHP { get; set; }
        public DbSet<ValoracionIL> ValoracionesIL { get; set; }

        public DbSet<CriterioMatriz> CriteriosMatrices { get; set; }
        public DbSet<CriterioFila> CriteriosFilas { get; set; }
        public DbSet<CriterioCelda> CriteriosCeldas { get; set; }


        public DbSet<AlternativaMatriz> AlternativasMatrices { get; set; }
        public DbSet<AlternativaFila> AlternativasFilas { get; set; }
        public DbSet<AlternativaCelda> AlternativasCeldas { get; set; }


        public DbSet<Etiqueta> Etiqueta { get; set; }
        public DbSet<ConjuntoEtiquetas> ConjuntoEtiquetas { get; set; }

        public DbSet<AlternativaIL> AlternativasIL { get; set; }
        public DbSet<ValorCriterio> ValoresCriterios { get; set; }

        
        public static GisiaExpertoContext Instance { get {return Lock._context; }}

        private class Lock
        {
            static Lock() { }
            internal static readonly GisiaExpertoContext _context = new GisiaExpertoContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();           

            modelBuilder.Entity<Proyecto>()
                .HasRequired(x => x.Creador)
                .WithMany(b => b.ProyectosCreados)
                .HasForeignKey(x => x.CreadorId).WillCascadeOnDelete(false);

            modelBuilder.Entity<ValoracionAHP>()
                .HasRequired(x => x.ExpertoEnProyecto);
            modelBuilder.Entity<ValoracionIL>()
                .HasRequired(x => x.ExpertoEnProyecto);
            
            //modelBuilder.Entity<Experto>()
            //    .HasMany(x => x.ProyectosAsignados)
            //    .WithRequired(x => x.Experto).WillCascadeOnDelete(true);

            //modelBuilder.Entity<ExpertoEnProyecto>()
            //    .HasOptional(x => x.ValoracionAHP)
            //    .WithRequired(x => x.ExpertoEnProyecto).WillCascadeOnDelete(true);

            //modelBuilder.Entity<ExpertoEnProyecto>()
            //    .HasOptional(x => x.ValoracionIL)
            //    .WithRequired(x => x.ExpertoEnProyecto).WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}