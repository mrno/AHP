namespace sisexperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creacionEtiquetas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etiquetas",
                c => new
                    {
                        EtiquetaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        a = c.Int(nullable: false),
                        b = c.Int(nullable: false),
                        c = c.Int(nullable: false),
                        ConjuntoEtiquetasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EtiquetaId)
                .ForeignKey("dbo.ConjuntoEtiquetas", t => t.ConjuntoEtiquetasId)
                .Index(t => t.ConjuntoEtiquetasId);
            
            CreateTable(
                "dbo.ConjuntoEtiquetas",
                c => new
                    {
                        ConjuntoEtiquetasId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConjuntoEtiquetasId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Etiquetas", new[] { "ConjuntoEtiquetasId" });
            DropForeignKey("dbo.Etiquetas", "ConjuntoEtiquetasId", "dbo.ConjuntoEtiquetas");
            DropTable("dbo.ConjuntoEtiquetas");
            DropTable("dbo.Etiquetas");
        }
    }
}
