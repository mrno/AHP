namespace sisexperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cero : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ValoracionCriteriosPorExpertos", newName: "ValoracionCriteriosPorExpertoes");
            DropForeignKey("dbo.ExpertosPonderadosEnProyectos", "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId", "dbo.ValoracionCriteriosPorExpertos");
            DropIndex("dbo.ExpertosPonderadosEnProyectos", new[] { "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId" });
            RenameColumn(table: "dbo.ValoracionCriteriosPorExpertoes", name: "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId", newName: "ExpertoEnProyecto_ProyectoId");
            AddColumn("dbo.ValoracionCriteriosPorExpertoes", "ExpertoEnProyecto_ExpertoId", c => c.Int());
            AddForeignKey("dbo.ValoracionCriteriosPorExpertoes", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" }, "dbo.ExpertosPonderadosEnProyectos", new[] { "ProyectoId", "ExpertoId" });
            CreateIndex("dbo.ValoracionCriteriosPorExpertoes", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.ValoracionCriteriosPorExpertoes", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" });
            DropForeignKey("dbo.ValoracionCriteriosPorExpertoes", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" }, "dbo.ExpertosPonderadosEnProyectos");
            DropColumn("dbo.ValoracionCriteriosPorExpertoes", "ExpertoEnProyecto_ExpertoId");
            RenameColumn(table: "dbo.ValoracionCriteriosPorExpertoes", name: "ExpertoEnProyecto_ProyectoId", newName: "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId");
            CreateIndex("dbo.ExpertosPonderadosEnProyectos", "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId");
            AddForeignKey("dbo.ExpertosPonderadosEnProyectos", "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId", "dbo.ValoracionCriteriosPorExpertos", "ValoracionCriteriosPorExpertoId");
            RenameTable(name: "dbo.ValoracionCriteriosPorExpertoes", newName: "ValoracionCriteriosPorExpertos");
        }
    }
}
