namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpertosPonderadosEnProyectos", "Peso", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpertosPonderadosEnProyectos", "Peso");
        }
    }
}
