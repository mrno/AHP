namespace sisexperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nuevo3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConjuntoEtiquetas", "Token", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConjuntoEtiquetas", "Token");
        }
    }
}
