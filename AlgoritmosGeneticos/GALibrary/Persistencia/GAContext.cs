using System.Data.Entity;

namespace GALibrary.Persistencia
{
    public class GAContext : DbContext
    {
        public GAContext()
            : base("DataContext")
        {
            
        }

        public DbSet<ConjuntoMatriz> ConjuntoMatrices { get; set; }
        public DbSet<ObjetoMatriz> Matrices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjetoMatriz>().HasMany(x => x.MatricesIncompletas).WithOptional(x => x.MatrizCompleta);
            modelBuilder.Entity<ObjetoMatriz>().HasOptional(x => x.MatrizMejorada);
            base.OnModelCreating(modelBuilder);
        }
    }
}
