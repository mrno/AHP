namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class administradores : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expertos", "Administrador", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expertos", "Administrador");
        }
    }
}
