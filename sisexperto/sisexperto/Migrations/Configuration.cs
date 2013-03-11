namespace sisexperto.Migrations
{
    using sisExperto.Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<sisExperto.Entidades.GisiaExpertoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(sisExperto.Entidades.GisiaExpertoContext context)
        {
            context.Expertos.AddOrUpdate(new Experto()
            {
                Usuario = "Admin",
                Nombre = "Usuario",
                Apellido = "Super",
                Administrador = true,
                Clave = "admin"
            });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
