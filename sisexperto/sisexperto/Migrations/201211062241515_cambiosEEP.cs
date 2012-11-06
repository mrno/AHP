namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosEEP : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExpertosPonderadosEnProyectos", "Peso", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExpertosPonderadosEnProyectos", "Peso", c => c.Double(nullable: false));
        }
    }
}
