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
    
    public partial class ValoracionILs
    {
        public ValoracionILs()
        {
            this.AlternativaILs = new HashSet<AlternativaILs>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ConjuntoEtiquetas_ConjuntoEtiquetasId { get; set; }
    
        public virtual ICollection<AlternativaILs> AlternativaILs { get; set; }
        public virtual ConjuntoEtiquetas ConjuntoEtiquetas { get; set; }
        public virtual ExpertosEnProyecto ExpertosEnProyecto { get; set; }
    }
}