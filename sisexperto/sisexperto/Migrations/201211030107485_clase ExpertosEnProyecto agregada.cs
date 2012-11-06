namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class claseExpertosEnProyectoagregada : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpertosPorProyecto", "ExpertoId", "dbo.Expertos");
            DropForeignKey("dbo.ExpertosPorProyecto", "ProyectoId", "dbo.Proyectos");
            DropIndex("dbo.ExpertosPorProyecto", new[] { "ExpertoId" });
            DropIndex("dbo.ExpertosPorProyecto", new[] { "ProyectoId" });
            CreateTable(
                "dbo.ExpertosPonderadosEnProyectos",
                c => new
                    {
                        ProyectoId = c.Int(nullable: false),
                        ExpertoId = c.Int(nullable: false),
                        Ponderacion = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProyectoId, t.ExpertoId })
                .ForeignKey("dbo.Proyectos", t => t.ProyectoId, cascadeDelete: true)
                .ForeignKey("dbo.Expertos", t => t.ExpertoId, cascadeDelete: true)
                .Index(t => t.ProyectoId)
                .Index(t => t.ExpertoId);
            
            DropTable("dbo.ExpertosPorProyecto");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExpertosPorProyecto",
                c => new
                    {
                        ExpertoId = c.Int(nullable: false),
                        ProyectoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExpertoId, t.ProyectoId });
            
            DropIndex("dbo.ExpertosPonderadosEnProyectos", new[] { "ExpertoId" });
            DropIndex("dbo.ExpertosPonderadosEnProyectos", new[] { "ProyectoId" });
            DropForeignKey("dbo.ExpertosPonderadosEnProyectos", "ExpertoId", "dbo.Expertos");
            DropForeignKey("dbo.ExpertosPonderadosEnProyectos", "ProyectoId", "dbo.Proyectos");
            DropTable("dbo.ExpertosPonderadosEnProyectos");
            CreateIndex("dbo.ExpertosPorProyecto", "ProyectoId");
            CreateIndex("dbo.ExpertosPorProyecto", "ExpertoId");
            AddForeignKey("dbo.ExpertosPorProyecto", "ProyectoId", "dbo.Proyectos", "ProyectoId", cascadeDelete: true);
            AddForeignKey("dbo.ExpertosPorProyecto", "ExpertoId", "dbo.Expertos", "ExpertoId", cascadeDelete: true);
        }
    }
}
