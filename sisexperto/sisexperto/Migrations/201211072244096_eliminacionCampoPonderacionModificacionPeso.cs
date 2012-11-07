namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eliminacionCampoPonderacionModificacionPeso : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ExpertosPonderadosEnProyectos", "Ponderacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExpertosPonderadosEnProyectos", "Ponderacion", c => c.Double(nullable: false));
        }
    }
}
