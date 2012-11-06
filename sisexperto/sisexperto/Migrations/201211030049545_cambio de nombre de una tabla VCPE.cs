namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiodenombredeunatablaVCPE : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ValoracionCriteriosPorExpertoes", newName: "ValoracionCriteriosPorExpertos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ValoracionCriteriosPorExpertos", newName: "ValoracionCriteriosPorExpertoes");
        }
    }
}
