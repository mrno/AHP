//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OWAOP
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExpertosEnProyecto
    {
        public ExpertosEnProyecto()
        {
            this.AlternativaMatrizs = new HashSet<AlternativaMatrizs>();
            this.CriterioMatrizs = new HashSet<CriterioMatrizs>();
        }
    
        public int ExpertoEnProyectoId { get; set; }
        public bool Activo { get; set; }
        public double Ponderacion { get; set; }
        public int Peso { get; set; }
        public Nullable<int> Proyecto_ProyectoId { get; set; }
        public int Experto_ExpertoId { get; set; }
    
        public virtual ICollection<AlternativaMatrizs> AlternativaMatrizs { get; set; }
        public virtual ICollection<CriterioMatrizs> CriterioMatrizs { get; set; }
        public virtual Expertos Expertos { get; set; }
        public virtual Proyectos Proyectos { get; set; }
        public virtual ValoracionAHPs ValoracionAHPs { get; set; }
        public virtual ValoracionILs ValoracionILs { get; set; }
    }
}