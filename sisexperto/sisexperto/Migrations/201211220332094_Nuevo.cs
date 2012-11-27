using System.Data.Entity.Migrations;

namespace sisexperto.Migrations
{
    public partial class Nuevo : DbMigration
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
                "dbo.ExpertosEnProyecto",
                c => new
                         {
                             ExpertoEnProyectoId = c.Int(nullable: false, identity: true),
                             ProyectoId = c.Int(nullable: false),
                             ExpertoId = c.Int(nullable: false),
                             Ponderacion = c.Double(nullable: false),
                             Peso = c.Int(nullable: false),
                             CriterioMatrizId = c.Int(nullable: false),
                             ConjuntoEtiquetas_ConjuntoEtiquetasId = c.Int(),
                         })
                .PrimaryKey(t => t.ExpertoEnProyectoId)
                .ForeignKey("dbo.Proyectos", t => t.ProyectoId, cascadeDelete: true)
                .ForeignKey("dbo.Expertos", t => t.ExpertoId, cascadeDelete: true)
                .ForeignKey("dbo.ConjuntoEtiquetas", t => t.ConjuntoEtiquetas_ConjuntoEtiquetasId)
                .Index(t => t.ProyectoId)
                .Index(t => t.ExpertoId)
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

            CreateTable(
                "dbo.Etiquetas",
                c => new
                         {
                             EtiquetaId = c.Int(nullable: false, identity: true),
                             Indice = c.Int(nullable: false),
                             Nombre = c.String(),
                             Descripcion = c.String(),
                             a = c.Double(nullable: false),
                             b = c.Double(nullable: false),
                             c = c.Double(nullable: false),
                             ConjuntoEtiquetas_ConjuntoEtiquetasId = c.Int(),
                         })
                .PrimaryKey(t => t.EtiquetaId)
                .ForeignKey("dbo.ConjuntoEtiquetas", t => t.ConjuntoEtiquetas_ConjuntoEtiquetasId)
                .Index(t => t.ConjuntoEtiquetas_ConjuntoEtiquetasId);

            CreateTable(
                "dbo.CriterioMatrizs",
                c => new
                         {
                             CriterioMatrizId = c.Int(nullable: false),
                             Consistencia = c.Boolean(nullable: false),
                         })
                .PrimaryKey(t => t.CriterioMatrizId)
                .ForeignKey("dbo.ExpertosEnProyecto", t => t.CriterioMatrizId)
                .Index(t => t.CriterioMatrizId);

            CreateTable(
                "dbo.CriterioFilas",
                c => new
                         {
                             CriterioFilaId = c.Int(nullable: false, identity: true),
                             CriterioId = c.Int(nullable: false),
                             CriterioMatriz_CriterioMatrizId = c.Int(),
                         })
                .PrimaryKey(t => t.CriterioFilaId)
                .ForeignKey("dbo.Criterios", t => t.CriterioId, cascadeDelete: true)
                .ForeignKey("dbo.CriterioMatrizs", t => t.CriterioMatriz_CriterioMatrizId)
                .Index(t => t.CriterioId)
                .Index(t => t.CriterioMatriz_CriterioMatrizId);

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
                "dbo.CriterioCeldas",
                c => new
                         {
                             CriterioCeldaId = c.Int(nullable: false, identity: true),
                             Fila = c.Int(nullable: false),
                             Columna = c.Int(nullable: false),
                             ValorAHP = c.Double(nullable: false),
                             ValorIL = c.Double(nullable: false),
                             CriterioId = c.Int(nullable: false),
                             CriterioFila_CriterioFilaId = c.Int(),
                         })
                .PrimaryKey(t => t.CriterioCeldaId)
                .ForeignKey("dbo.Criterios", t => t.CriterioId, cascadeDelete: true)
                .ForeignKey("dbo.CriterioFilas", t => t.CriterioFila_CriterioFilaId)
                .Index(t => t.CriterioId)
                .Index(t => t.CriterioFila_CriterioFilaId);

            CreateTable(
                "dbo.AlternativaMatrizs",
                c => new
                         {
                             AlternativaMatrizId = c.Int(nullable: false, identity: true),
                             Consistencia = c.Boolean(nullable: false),
                             CriterioId = c.Int(nullable: false),
                             ExpertoEnProyecto_ExpertoEnProyectoId = c.Int(),
                         })
                .PrimaryKey(t => t.AlternativaMatrizId)
                .ForeignKey("dbo.Criterios", t => t.CriterioId, cascadeDelete: true)
                .ForeignKey("dbo.ExpertosEnProyecto", t => t.ExpertoEnProyecto_ExpertoEnProyectoId)
                .Index(t => t.CriterioId)
                .Index(t => t.ExpertoEnProyecto_ExpertoEnProyectoId);

            CreateTable(
                "dbo.AlternativaFilas",
                c => new
                         {
                             AlternativaFilaId = c.Int(nullable: false, identity: true),
                             AlternativaId = c.Int(nullable: false),
                             AlternativaMatriz_AlternativaMatrizId = c.Int(),
                         })
                .PrimaryKey(t => t.AlternativaFilaId)
                .ForeignKey("dbo.Alternativas", t => t.AlternativaId, cascadeDelete: true)
                .ForeignKey("dbo.AlternativaMatrizs", t => t.AlternativaMatriz_AlternativaMatrizId)
                .Index(t => t.AlternativaId)
                .Index(t => t.AlternativaMatriz_AlternativaMatrizId);

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
                "dbo.AlternativaCeldas",
                c => new
                         {
                             AlternativaCeldaId = c.Int(nullable: false, identity: true),
                             Fila = c.Int(nullable: false),
                             Columna = c.Int(nullable: false),
                             ValorAHP = c.Double(nullable: false),
                             ValorIL = c.Double(nullable: false),
                             AlternativaId = c.Int(nullable: false),
                             AlternativaFila_AlternativaFilaId = c.Int(),
                         })
                .PrimaryKey(t => t.AlternativaCeldaId)
                .ForeignKey("dbo.Alternativas", t => t.AlternativaId, cascadeDelete: true)
                .ForeignKey("dbo.AlternativaFilas", t => t.AlternativaFila_AlternativaFilaId)
                .Index(t => t.AlternativaId)
                .Index(t => t.AlternativaFila_AlternativaFilaId);
        }

        public override void Down()
        {
            DropIndex("dbo.AlternativaCeldas", new[] {"AlternativaFila_AlternativaFilaId"});
            DropIndex("dbo.AlternativaCeldas", new[] {"AlternativaId"});
            DropIndex("dbo.Alternativas", new[] {"ProyectoId"});
            DropIndex("dbo.AlternativaFilas", new[] {"AlternativaMatriz_AlternativaMatrizId"});
            DropIndex("dbo.AlternativaFilas", new[] {"AlternativaId"});
            DropIndex("dbo.AlternativaMatrizs", new[] {"ExpertoEnProyecto_ExpertoEnProyectoId"});
            DropIndex("dbo.AlternativaMatrizs", new[] {"CriterioId"});
            DropIndex("dbo.CriterioCeldas", new[] {"CriterioFila_CriterioFilaId"});
            DropIndex("dbo.CriterioCeldas", new[] {"CriterioId"});
            DropIndex("dbo.Criterios", new[] {"ProyectoId"});
            DropIndex("dbo.CriterioFilas", new[] {"CriterioMatriz_CriterioMatrizId"});
            DropIndex("dbo.CriterioFilas", new[] {"CriterioId"});
            DropIndex("dbo.CriterioMatrizs", new[] {"CriterioMatrizId"});
            DropIndex("dbo.Etiquetas", new[] {"ConjuntoEtiquetas_ConjuntoEtiquetasId"});
            DropIndex("dbo.ExpertosEnProyecto", new[] {"ConjuntoEtiquetas_ConjuntoEtiquetasId"});
            DropIndex("dbo.ExpertosEnProyecto", new[] {"ExpertoId"});
            DropIndex("dbo.ExpertosEnProyecto", new[] {"ProyectoId"});
            DropIndex("dbo.Proyectos", new[] {"CreadorId"});
            DropForeignKey("dbo.AlternativaCeldas", "AlternativaFila_AlternativaFilaId", "dbo.AlternativaFilas");
            DropForeignKey("dbo.AlternativaCeldas", "AlternativaId", "dbo.Alternativas");
            DropForeignKey("dbo.Alternativas", "ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.AlternativaFilas", "AlternativaMatriz_AlternativaMatrizId", "dbo.AlternativaMatrizs");
            DropForeignKey("dbo.AlternativaFilas", "AlternativaId", "dbo.Alternativas");
            DropForeignKey("dbo.AlternativaMatrizs", "ExpertoEnProyecto_ExpertoEnProyectoId", "dbo.ExpertosEnProyecto");
            DropForeignKey("dbo.AlternativaMatrizs", "CriterioId", "dbo.Criterios");
            DropForeignKey("dbo.CriterioCeldas", "CriterioFila_CriterioFilaId", "dbo.CriterioFilas");
            DropForeignKey("dbo.CriterioCeldas", "CriterioId", "dbo.Criterios");
            DropForeignKey("dbo.Criterios", "ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.CriterioFilas", "CriterioMatriz_CriterioMatrizId", "dbo.CriterioMatrizs");
            DropForeignKey("dbo.CriterioFilas", "CriterioId", "dbo.Criterios");
            DropForeignKey("dbo.CriterioMatrizs", "CriterioMatrizId", "dbo.ExpertosEnProyecto");
            DropForeignKey("dbo.Etiquetas", "ConjuntoEtiquetas_ConjuntoEtiquetasId", "dbo.ConjuntoEtiquetas");
            DropForeignKey("dbo.ExpertosEnProyecto", "ConjuntoEtiquetas_ConjuntoEtiquetasId", "dbo.ConjuntoEtiquetas");
            DropForeignKey("dbo.ExpertosEnProyecto", "ExpertoId", "dbo.Expertos");
            DropForeignKey("dbo.ExpertosEnProyecto", "ProyectoId", "dbo.Proyectos");
            DropForeignKey("dbo.Proyectos", "CreadorId", "dbo.Expertos");
            DropTable("dbo.AlternativaCeldas");
            DropTable("dbo.Alternativas");
            DropTable("dbo.AlternativaFilas");
            DropTable("dbo.AlternativaMatrizs");
            DropTable("dbo.CriterioCeldas");
            DropTable("dbo.Criterios");
            DropTable("dbo.CriterioFilas");
            DropTable("dbo.CriterioMatrizs");
            DropTable("dbo.Etiquetas");
            DropTable("dbo.ConjuntoEtiquetas");
            DropTable("dbo.ExpertosEnProyecto");
            DropTable("dbo.Expertos");
            DropTable("dbo.Proyectos");
        }
    }
}