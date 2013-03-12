namespace sisexperto.Migrations
{
    using sisexperto.Entidades;
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
                ExpertoId = 1,
                Usuario = "Admin",
                Nombre = "Usuario",
                Apellido = "Super",
                Administrador = true,
                Clave = "admin"
            });

            //context.ConjuntoEtiquetas.AddOrUpdate(new ConjuntoEtiquetas
            //{
            //    ConjuntoEtiquetasId = 1,
            //    Cantidad = 3,
            //    Etiquetas = new System.Collections.Generic.List<Etiqueta>(),
            //    Nombre = "Estándar3",
            //    Descripcion = "Conjunto de etiquetas estándar de 3 etiquetas",
            //    Tipo = 0,
            //    Token = 0
            //});

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
