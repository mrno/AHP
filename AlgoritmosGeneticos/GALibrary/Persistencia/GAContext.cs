using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GALibrary.Persistencia
{
    public class GAContext : DbContext
    {
        public GAContext()
            : base("DataContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<SesionExperimentacion> Sesiones { get; set; }
        public DbSet<ResultadoExperimento> Experimentos { get; set; }
        public DbSet<ConjuntoOrdenN> ConjuntosOrdenN { get; set; }
        public DbSet<ConjuntoMatriz> ConjuntoMatrices { get; set; }
        public DbSet<ObjetoMatriz> Matrices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjetoMatriz>().HasMany(x => x.MatricesIncompletas).WithOptional(x => x.MatrizCompleta);
            modelBuilder.Entity<ObjetoMatriz>().HasMany(x => x.Experimentos).WithRequired(x => x.MatrizOriginal);
            modelBuilder.Entity<ResultadoExperimento>().HasOptional(x => x.MatrizMejorada);
            base.OnModelCreating(modelBuilder);
        }
    }
}
