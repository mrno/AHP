namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proyectoCambios : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Proyectos", "Estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proyectos", "Estado", c => c.Int(nullable: false));
        }
    }
}
