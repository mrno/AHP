namespace sisExperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GisiaExpertoContextcreador : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proyectos",
                c => new
                    {
                        ProyectoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Objetivo = c.String(),
                        CreadorId = c.Int(nullable: false),
                        Creador_ExpertoId = c.Int(),
                    })
                .PrimaryKey(t => t.ProyectoId)
                .ForeignKey("dbo.Expertos", t => t.Creador_ExpertoId)
                .Index(t => t.Creador_ExpertoId);
            
            CreateTable(
                "dbo.Expertos",
                c => new
                    {
                        ExpertoId = c.Int(nullable: false, identity: true),
                        Apellido = c.String(),
                        Nombre = c.String(),
                        Usuario = c.String(),
                        Clave = c.String(),
                    })
                .PrimaryKey(t => t.ExpertoId);
            
            CreateTable(
                "dbo.Criterios",
                c => new
                    {
                        CriterioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        ProyectoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CriterioId)
                .ForeignKey("dbo.Proyectos", t => t.ProyectoId, cascadeDelete: true)
                .Index(t => t.ProyectoId);
            
            CreateTable(
                "dbo.ValoracionAlternativasPorCriterioExperto",
                c => new
                    {
                        ValoracionAlternativasPorCriterioExpertoId = c.Int(nullable: false, identity: true),
                        Consistencia = c.Boolean(nullable: false),
                        ExpertoId = c.Int(nullable: false),
                        AlternativaId = c.Int(nullable: false),
                        Criterio_CriterioId = c.Int(),
                    })
                .PrimaryKey(t => t.ValoracionAlternativasPorCriterioExpertoId)
                .ForeignKey("dbo.Expertos", t => t.ExpertoId, cascadeDelete: true)
                .ForeignKey("dbo.Alternativas", t => t.AlternativaId, cascadeDelete: true)
                .ForeignKey("dbo.Criterios", t => t.Criterio_CriterioId)
                .Index(t => t.ExpertoId)
                .Index(t => t.AlternativaId)
                .Index(t => t.Criterio_CriterioId);
            
            CreateTable(
                "dbo.Alternativas",
                c => new
                    {
                        AlternativaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        ProyectoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlternativaId)
                .ForeignKey("dbo.Proyectos", t => t.ProyectoId, cascadeDelete: true)
                .Index(t => t.ProyectoId);
            
            CreateTable(
                "dbo.ComparacionAlternativas",
                c => new
                    {
                        ComparacionAlternativaId = c.Int(nullable: false, identity: true),
                        Fila = c.Int(nullable: false),
                        Columna = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        AlternativaId = c.Int(nullable: false),
                        ValoracionAlternativasPorCriterioExperto_ValoracionAlternativasPorCriterioExpertoId = c.Int(),
                    })
                .PrimaryKey(t => t.ComparacionAlternativaId)
                .ForeignKey("dbo.Alternativas", t => t.AlternativaId, cascadeDelete: true)
                .ForeignKey("dbo.ValoracionAlternativasPorCriterioExperto", t => t.ValoracionAlternativasPorCriterioExperto_ValoracionAlternativasPorCriterioExpertoId)
                .Index(t => t.AlternativaId)
                .Index(t => t.ValoracionAlternativasPorCriterioExperto_ValoracionAlternativasPorCriterioExpertoId);
            
            CreateTable(
                "dbo.ValoracionCriteriosPorExpertoes",
                c => new
                    {
                        ValoracionCriteriosPorExpertoId = c.Int(nullable: false, identity: true),
                        Consistencia = c.Boolean(nullable: false),
                        ExpertoId = c.Int(nullable: false),
                        CriterioId = c.Int(nullable: false),
                        Proyecto_ProyectoId = c.Int(),
                    })
                .PrimaryKey(t => t.ValoracionCriteriosPorExpertoId)
                .ForeignKey("dbo.Expertos", t => t.ExpertoId, cascadeDelete: true)
                .ForeignKey("dbo.Criterios", t => t.CriterioId, cascadeDelete: true)
                .ForeignKey("dbo.Proyectos", t => t.Proyecto_ProyectoId)
                .Index(t => t.ExpertoId)
                .Index(t => t.CriterioId)
                .Index(t => t.Proyecto_ProyectoId);
            
            CreateTable(
                "dbo.ComparacionCriterios",
                c => new
                    {
                        ComparacionCriterioId = c.Int(nullable: false, identity: true),
                        Fila = c.Int(nullable: false),
                        Columna = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        CriterioId = c.Int(nullable: false),
                        ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId = c.Int(),
                    })
                .PrimaryKey(t => t.ComparacionCriterioId)
                .ForeignKey("dbo.Criterios", t => t.CriterioId, cascadeDelete: true)
                .ForeignKey("dbo.ValoracionCriteriosPorExpertoes", t => t.ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId)
                .Index(t => t.CriterioId)
                .Index(t => t.ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId);
            
            CreateTable(
                "dbo.ExpertosPorProyecto",
                c => new
                    {
                        ExpertoId = c.Int(nullable: false),
                        ProyectoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExpertoId, t.ProyectoId })
                .ForeignKey("dbo.Expertos", t => t.ExpertoId, cascadeDelete: true)
                .ForeignKey("dbo.Proyectos", t => t.ProyectoId, cascadeDelete: true)
                .Index(t => t.ExpertoId)
                .Index(t => t.ProyectoId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ExpertosPorProyecto", new[] { "ProyectoId" });
            DropIndex("dbo.ExpertosPorProyecto", new[] { "ExpertoId" });
            DropIndex("dbo.ComparacionCriterios", new[] { "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId" });
            DropIndex("dbo.ComparacionCriterios", new[] { "CriterioId" });
            DropIndex("dbo.ValoracionCriteriosPorExpertoes", new[] { "Proyecto_ProyectoId" });
            DropIndex("dbo.ValoracionCriteriosPorExpertoes", new[] { "CriterioId" });
            DropIndex("dbo.ValoracionCriteriosPorExpertoes", new[] { "ExpertoId" });
            DropIndex("dbo.ComparacionAlternativas", new[] { "ValoracionAlternativasPorCriterioExperto_ValoracionAlternativasPorCriterioExpertoId" });
            DropIndex("dbo.ComparacionAlternativas", new[] { "AlternativaId" });
            DropIndex("dbo.Alternativas", new[] { "ProyectoId" });
            DropIndex("dbo.ValoracionAlternativasPorCriterioExperto", new[] { "Criterio_CriterioId" });
            DropIndex("dbo.ValoracionAlternativasPorCriterioExperto", new[] { "AlternativaId" });
            DropIndex("dbo.ValoracionAlternativasPorCriterioExperto", new[] { "ExpertoId" });
            DropIndex("dbo.Criterios", new[] { "ProyectoId" });
            DropIndex("dbo.Proyectos", new[] { "Creador_ExpertoId" });
            DropForeignKey("dbo.ExpertosPorProyecto", "ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.ExpertosPorProyecto", "ExpertoId", "dbo.Expertos");
            DropForeignKey("dbo.ComparacionCriterios", "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId", "dbo.ValoracionCriteriosPorExpertoes");
            DropForeignKey("dbo.ComparacionCriterios", "CriterioId", "dbo.Criterios");
            DropForeignKey("dbo.ValoracionCriteriosPorExpertoes", "Proyecto_ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.ValoracionCriteriosPorExpertoes", "CriterioId", "dbo.Criterios");
            DropForeignKey("dbo.ValoracionCriteriosPorExpertoes", "ExpertoId", "dbo.Expertos");
            DropForeignKey("dbo.ComparacionAlternativas", "ValoracionAlternativasPorCriterioExperto_ValoracionAlternativasPorCriterioExpertoId", "dbo.ValoracionAlternativasPorCriterioExperto");
            DropForeignKey("dbo.ComparacionAlternativas", "AlternativaId", "dbo.Alternativas");
            DropForeignKey("dbo.Alternativas", "ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.ValoracionAlternativasPorCriterioExperto", "Criterio_CriterioId", "dbo.Criterios");
            DropForeignKey("dbo.ValoracionAlternativasPorCriterioExperto", "AlternativaId", "dbo.Alternativas");
            DropForeignKey("dbo.ValoracionAlternativasPorCriterioExperto", "ExpertoId", "dbo.Expertos");
            DropForeignKey("dbo.Criterios", "ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.Proyectos", "Creador_ExpertoId", "dbo.Expertos");
            DropTable("dbo.ExpertosPorProyecto");
            DropTable("dbo.ComparacionCriterios");
            DropTable("dbo.ValoracionCriteriosPorExpertoes");
            DropTable("dbo.ComparacionAlternativas");
            DropTable("dbo.Alternativas");
            DropTable("dbo.ValoracionAlternativasPorCriterioExperto");
            DropTable("dbo.Criterios");
            DropTable("dbo.Expertos");
            DropTable("dbo.Proyectos");
        }
    }
}
