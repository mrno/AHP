using System.Data.Entity.Migrations;

namespace sisexperto.Migrations
{
    public partial class Nuevo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CriterioMatrizs", "ExpertoEnProyectoId", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.CriterioMatrizs", "ExpertoEnProyectoId");
        }
    }
}