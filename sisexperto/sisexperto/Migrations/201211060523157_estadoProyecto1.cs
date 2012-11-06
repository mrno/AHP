namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadoProyecto1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyectos", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proyectos", "Estado");
        }
    }
}
