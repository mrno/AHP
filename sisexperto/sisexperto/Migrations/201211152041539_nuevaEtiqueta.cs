namespace sisexperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevaEtiqueta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Etiquetas", "ConjuntoEtiquetasId", "dbo.ConjuntoEtiquetas");
            DropIndex("dbo.Etiquetas", new[] { "ConjuntoEtiquetasId" });
            RenameColumn(table: "dbo.Etiquetas", name: "ConjuntoEtiquetasId", newName: "ConjuntoEtiquetas_ConjuntoEtiquetasId");
            AddForeignKey("dbo.Etiquetas", "ConjuntoEtiquetas_ConjuntoEtiquetasId", "dbo.ConjuntoEtiquetas", "ConjuntoEtiquetasId");
            CreateIndex("dbo.Etiquetas", "ConjuntoEtiquetas_ConjuntoEtiquetasId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Etiquetas", new[] { "ConjuntoEtiquetas_ConjuntoEtiquetasId" });
            DropForeignKey("dbo.Etiquetas", "ConjuntoEtiquetas_ConjuntoEtiquetasId", "dbo.ConjuntoEtiquetas");
            RenameColumn(table: "dbo.Etiquetas", name: "ConjuntoEtiquetas_ConjuntoEtiquetasId", newName: "ConjuntoEtiquetasId");
            CreateIndex("dbo.Etiquetas", "ConjuntoEtiquetasId");
            AddForeignKey("dbo.Etiquetas", "ConjuntoEtiquetasId", "dbo.ConjuntoEtiquetas", "ConjuntoEtiquetasId", cascadeDelete: true);
        }
    }
}
