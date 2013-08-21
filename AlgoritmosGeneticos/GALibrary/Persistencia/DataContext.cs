using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GALibrary.Persistencia
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DataContextNuevo")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<ConjuntoOrdenN> ConjuntosOrdenN { get; set; }
        public DbSet<ConjuntoMatriz> ConjuntoMatrices { get; set; }
        public DbSet<ObjetoMatriz> Matrices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjetoMatriz>().HasMany(x => x.MatricesIncompletas).WithOptional(x => x.MatrizCompleta);
            modelBuilder.Entity<ObjetoMatriz>().HasMany(x => x.Correcciones).WithRequired(x => x.MatrizOriginal);
            modelBuilder.Entity<Correccion>().HasOptional(x => x.MatrizCorregida);
            base.OnModelCreating(modelBuilder);
        }
    }
}
