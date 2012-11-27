using System.Data.Entity.Migrations;

namespace sisexperto.Migrations
{
    public partial class Nuevo2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ExpertosEnProyecto", "CriterioMatrizId");
            DropColumn("dbo.CriterioMatrizs", "ExpertoEnProyectoId");
        }

        public override void Down()
        {
            AddColumn("dbo.CriterioMatrizs", "ExpertoEnProyectoId", c => c.Int(nullable: false));
            AddColumn("dbo.ExpertosEnProyecto", "CriterioMatrizId", c => c.Int(nullable: false));
        }
    }
}