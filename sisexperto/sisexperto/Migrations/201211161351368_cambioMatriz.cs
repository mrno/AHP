namespace sisexperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambioMatriz : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpertosPonderadosEnProyectos", "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId", "dbo.ValoracionCriteriosPorExpertos");
            DropIndex("dbo.ExpertosPonderadosEnProyectos", new[] { "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId" });
            RenameColumn(table: "dbo.ValoracionCriteriosPorExpertos", name: "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId", newName: "ExpertoEnProyecto_ProyectoId");
            AddColumn("dbo.ValoracionCriteriosPorExpertos", "ExpertoEnProyecto_ExpertoId", c => c.Int());
            AddForeignKey("dbo.ValoracionCriteriosPorExpertos", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" }, "dbo.ExpertosPonderadosEnProyectos", new[] { "ProyectoId", "ExpertoId" });
            CreateIndex("dbo.ValoracionCriteriosPorExpertos", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.ValoracionCriteriosPorExpertos", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" });
            DropForeignKey("dbo.ValoracionCriteriosPorExpertos", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" }, "dbo.ExpertosPonderadosEnProyectos");
            DropColumn("dbo.ValoracionCriteriosPorExpertos", "ExpertoEnProyecto_ExpertoId");
            RenameColumn(table: "dbo.ValoracionCriteriosPorExpertos", name: "ExpertoEnProyecto_ProyectoId", newName: "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId");
            CreateIndex("dbo.ExpertosPonderadosEnProyectos", "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId");
            AddForeignKey("dbo.ExpertosPonderadosEnProyectos", "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId", "dbo.ValoracionCriteriosPorExpertos", "ValoracionCriteriosPorExpertoId");
        }
    }
}
