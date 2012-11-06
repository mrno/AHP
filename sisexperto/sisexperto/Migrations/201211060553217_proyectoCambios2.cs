namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proyectoCambios2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Proyectos", "Creador_ExpertoId", "dbo.Expertos");
            DropIndex("dbo.Proyectos", new[] { "Creador_ExpertoId" });
            AddColumn("dbo.Proyectos", "Estado", c => c.String());
            AddForeignKey("dbo.Proyectos", "CreadorId", "dbo.Expertos", "ExpertoId");
            CreateIndex("dbo.Proyectos", "CreadorId");
            DropColumn("dbo.Proyectos", "Creador_ExpertoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proyectos", "Creador_ExpertoId", c => c.Int());
            DropIndex("dbo.Proyectos", new[] { "CreadorId" });
            DropForeignKey("dbo.Proyectos", "CreadorId", "dbo.Expertos");
            DropColumn("dbo.Proyectos", "Estado");
            CreateIndex("dbo.Proyectos", "Creador_ExpertoId");
            AddForeignKey("dbo.Proyectos", "Creador_ExpertoId", "dbo.Expertos", "ExpertoId");
        }
    }
}
