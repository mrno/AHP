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
    
    public partial class AlternativaFilas
    {
        public AlternativaFilas()
        {
            this.AlternativaCeldas = new HashSet<AlternativaCeldas>();
        }
    
        public int AlternativaFilaId { get; set; }
        public int AlternativaId { get; set; }
        public Nullable<int> AlternativaMatriz_AlternativaMatrizId { get; set; }
    
        public virtual ICollection<AlternativaCeldas> AlternativaCeldas { get; set; }
        public virtual AlternativaMatrizs AlternativaMatrizs { get; set; }
        public virtual Alternativas Alternativas { get; set; }
    }
}