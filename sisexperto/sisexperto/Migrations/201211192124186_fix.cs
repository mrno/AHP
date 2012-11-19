namespace sisexperto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
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
                        Estado = c.String(),
                        Tipo = c.Int(nullable: false),
                        CreadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProyectoId)
                .ForeignKey("dbo.Expertos", t => t.CreadorId)
                .Index(t => t.CreadorId);
            
            CreateTable(
                "dbo.Expertos",
                c => new
                    {
                        ExpertoId = c.Int(nullable: false, identity: true),
                        Apellido = c.String(),
                        Nombre = c.String(),
                        Usuario = c.String(),
                        Clave = c.String(),
                        Administrador = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ExpertoId);
            
            CreateTable(
                "dbo.ExpertosPonderadosEnProyectos",
                c => new
                    {
                        ProyectoId = c.Int(nullable: false),
                        ExpertoId = c.Int(nullable: false),
                        Ponderacion = c.Double(nullable: false),
                        Peso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProyectoId, t.ExpertoId })
                .ForeignKey("dbo.Proyectos", t => t.ProyectoId, cascadeDelete: true)
                .ForeignKey("dbo.Expertos", t => t.ExpertoId, cascadeDelete: true)
                .Index(t => t.ProyectoId)
                .Index(t => t.ExpertoId);
            
            CreateTable(
                "dbo.ValoracionCriteriosPorExpertoes",
                c => new
                    {
                        ValoracionCriteriosPorExpertoId = c.Int(nullable: false, identity: true),
                        Consistencia = c.Boolean(nullable: false),
                        ExpertoId = c.Int(nullable: false),
                        CriterioId = c.Int(nullable: false),
                        ExpertoEnProyecto_ProyectoId = c.Int(),
                        ExpertoEnProyecto_ExpertoId = c.Int(),
                        Proyecto_ProyectoId = c.Int(),
                    })
                .PrimaryKey(t => t.ValoracionCriteriosPorExpertoId)
                .ForeignKey("dbo.Expertos", t => t.ExpertoId, cascadeDelete: true)
                .ForeignKey("dbo.Criterios", t => t.CriterioId, cascadeDelete: true)
                .ForeignKey("dbo.ExpertosPonderadosEnProyectos", t => new { t.ExpertoEnProyecto_ProyectoId, t.ExpertoEnProyecto_ExpertoId })
                .ForeignKey("dbo.Proyectos", t => t.Proyecto_ProyectoId)
                .Index(t => t.ExpertoId)
                .Index(t => t.CriterioId)
                .Index(t => new { t.ExpertoEnProyecto_ProyectoId, t.ExpertoEnProyecto_ExpertoId })
                .Index(t => t.Proyecto_ProyectoId);
            
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
                        ExpertoEnProyecto_ProyectoId = c.Int(),
                        ExpertoEnProyecto_ExpertoId = c.Int(),
                    })
                .PrimaryKey(t => t.ValoracionAlternativasPorCriterioExpertoId)
                .ForeignKey("dbo.Expertos", t => t.ExpertoId, cascadeDelete: true)
                .ForeignKey("dbo.Alternativas", t => t.AlternativaId, cascadeDelete: true)
                .ForeignKey("dbo.Criterios", t => t.Criterio_CriterioId)
                .ForeignKey("dbo.ExpertosPonderadosEnProyectos", t => new { t.ExpertoEnProyecto_ProyectoId, t.ExpertoEnProyecto_ExpertoId })
                .Index(t => t.ExpertoId)
                .Index(t => t.AlternativaId)
                .Index(t => t.Criterio_CriterioId)
                .Index(t => new { t.ExpertoEnProyecto_ProyectoId, t.ExpertoEnProyecto_ExpertoId });
            
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
                        ValorAHP = c.Double(nullable: false),
                        ValorIL = c.Double(nullable: false),
                        AlternativaId = c.Int(nullable: false),
                        ValoracionAlternativasPorCriterioExperto_ValoracionAlternativasPorCriterioExpertoId = c.Int(),
                    })
                .PrimaryKey(t => t.ComparacionAlternativaId)
                .ForeignKey("dbo.Alternativas", t => t.AlternativaId, cascadeDelete: true)
                .ForeignKey("dbo.ValoracionAlternativasPorCriterioExperto", t => t.ValoracionAlternativasPorCriterioExperto_ValoracionAlternativasPorCriterioExpertoId)
                .Index(t => t.AlternativaId)
                .Index(t => t.ValoracionAlternativasPorCriterioExperto_ValoracionAlternativasPorCriterioExpertoId);
            
            CreateTable(
                "dbo.ComparacionCriterios",
                c => new
                    {
                        ComparacionCriterioId = c.Int(nullable: false, identity: true),
                        Fila = c.Int(nullable: false),
                        Columna = c.Int(nullable: false),
                        ValorAHP = c.Double(nullable: false),
                        ValorIL = c.Double(nullable: false),
                        CriterioId = c.Int(nullable: false),
                        ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId = c.Int(),
                    })
                .PrimaryKey(t => t.ComparacionCriterioId)
                .ForeignKey("dbo.Criterios", t => t.CriterioId, cascadeDelete: true)
                .ForeignKey("dbo.ValoracionCriteriosPorExpertoes", t => t.ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId)
                .Index(t => t.CriterioId)
                .Index(t => t.ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId);
            
            CreateTable(
                "dbo.Etiquetas",
                c => new
                    {
                        EtiquetaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        a = c.Int(nullable: false),
                        b = c.Int(nullable: false),
                        c = c.Int(nullable: false),
                        ConjuntoEtiquetas_ConjuntoEtiquetasId = c.Int(),
                    })
                .PrimaryKey(t => t.EtiquetaId)
                .ForeignKey("dbo.ConjuntoEtiquetas", t => t.ConjuntoEtiquetas_ConjuntoEtiquetasId)
                .Index(t => t.ConjuntoEtiquetas_ConjuntoEtiquetasId);
            
            CreateTable(
                "dbo.ConjuntoEtiquetas",
                c => new
                    {
                        ConjuntoEtiquetasId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConjuntoEtiquetasId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Etiquetas", new[] { "ConjuntoEtiquetas_ConjuntoEtiquetasId" });
            DropIndex("dbo.ComparacionCriterios", new[] { "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId" });
            DropIndex("dbo.ComparacionCriterios", new[] { "CriterioId" });
            DropIndex("dbo.ComparacionAlternativas", new[] { "ValoracionAlternativasPorCriterioExperto_ValoracionAlternativasPorCriterioExpertoId" });
            DropIndex("dbo.ComparacionAlternativas", new[] { "AlternativaId" });
            DropIndex("dbo.Alternativas", new[] { "ProyectoId" });
            DropIndex("dbo.ValoracionAlternativasPorCriterioExperto", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" });
            DropIndex("dbo.ValoracionAlternativasPorCriterioExperto", new[] { "Criterio_CriterioId" });
            DropIndex("dbo.ValoracionAlternativasPorCriterioExperto", new[] { "AlternativaId" });
            DropIndex("dbo.ValoracionAlternativasPorCriterioExperto", new[] { "ExpertoId" });
            DropIndex("dbo.Criterios", new[] { "ProyectoId" });
            DropIndex("dbo.ValoracionCriteriosPorExpertoes", new[] { "Proyecto_ProyectoId" });
            DropIndex("dbo.ValoracionCriteriosPorExpertoes", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" });
            DropIndex("dbo.ValoracionCriteriosPorExpertoes", new[] { "CriterioId" });
            DropIndex("dbo.ValoracionCriteriosPorExpertoes", new[] { "ExpertoId" });
            DropIndex("dbo.ExpertosPonderadosEnProyectos", new[] { "ExpertoId" });
            DropIndex("dbo.ExpertosPonderadosEnProyectos", new[] { "ProyectoId" });
            DropIndex("dbo.Proyectos", new[] { "CreadorId" });
            DropForeignKey("dbo.Etiquetas", "ConjuntoEtiquetas_ConjuntoEtiquetasId", "dbo.ConjuntoEtiquetas");
            DropForeignKey("dbo.ComparacionCriterios", "ValoracionCriteriosPorExperto_ValoracionCriteriosPorExpertoId", "dbo.ValoracionCriteriosPorExpertoes");
            DropForeignKey("dbo.ComparacionCriterios", "CriterioId", "dbo.Criterios");
            DropForeignKey("dbo.ComparacionAlternativas", "ValoracionAlternativasPorCriterioExperto_ValoracionAlternativasPorCriterioExpertoId", "dbo.ValoracionAlternativasPorCriterioExperto");
            DropForeignKey("dbo.ComparacionAlternativas", "AlternativaId", "dbo.Alternativas");
            DropForeignKey("dbo.Alternativas", "ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.ValoracionAlternativasPorCriterioExperto", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" }, "dbo.ExpertosPonderadosEnProyectos");
            DropForeignKey("dbo.ValoracionAlternativasPorCriterioExperto", "Criterio_CriterioId", "dbo.Criterios");
            DropForeignKey("dbo.ValoracionAlternativasPorCriterioExperto", "AlternativaId", "dbo.Alternativas");
            DropForeignKey("dbo.ValoracionAlternativasPorCriterioExperto", "ExpertoId", "dbo.Expertos");
            DropForeignKey("dbo.Criterios", "ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.ValoracionCriteriosPorExpertoes", "Proyecto_ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.ValoracionCriteriosPorExpertoes", new[] { "ExpertoEnProyecto_ProyectoId", "ExpertoEnProyecto_ExpertoId" }, "dbo.ExpertosPonderadosEnProyectos");
            DropForeignKey("dbo.ValoracionCriteriosPorExpertoes", "CriterioId", "dbo.Criterios");
            DropForeignKey("dbo.ValoracionCriteriosPorExpertoes", "ExpertoId", "dbo.Expertos");
            DropForeignKey("dbo.ExpertosPonderadosEnProyectos", "ExpertoId", "dbo.Expertos");
            DropForeignKey("dbo.ExpertosPonderadosEnProyectos", "ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.Proyectos", "CreadorId", "dbo.Expertos");
            DropTable("dbo.ConjuntoEtiquetas");
            DropTable("dbo.Etiquetas");
            DropTable("dbo.ComparacionCriterios");
            DropTable("dbo.ComparacionAlternativas");
            DropTable("dbo.Alternativas");
            DropTable("dbo.ValoracionAlternativasPorCriterioExperto");
            DropTable("dbo.Criterios");
            DropTable("dbo.ValoracionCriteriosPorExpertoes");
            DropTable("dbo.ExpertosPonderadosEnProyectos");
            DropTable("dbo.Expertos");
            DropTable("dbo.Proyectos");
        }
    }
}
