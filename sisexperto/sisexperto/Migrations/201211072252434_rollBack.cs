namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollBack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpertosPonderadosEnProyectos", "Ponderacion", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpertosPonderadosEnProyectos", "Ponderacion");
        }
    }
}
