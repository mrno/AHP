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
    
    public partial class Proyectos
    {
        public Proyectos()
        {
            this.Alternativas = new HashSet<Alternativas>();
            this.ConjuntoEtiquetas = new HashSet<ConjuntoEtiquetas>();
            this.Criterios = new HashSet<Criterios>();
            this.ExpertosEnProyecto = new HashSet<ExpertosEnProyecto>();
        }
    
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Objetivo { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> ProyectoClonadoId { get; set; }
        public int CreadorId { get; set; }
    
        public virtual ICollection<Alternativas> Alternativas { get; set; }
        public virtual ICollection<ConjuntoEtiquetas> ConjuntoEtiquetas { get; set; }
        public virtual ICollection<Criterios> Criterios { get; set; }
        public virtual Expertos Expertos { get; set; }
        public virtual ICollection<ExpertosEnProyecto> ExpertosEnProyecto { get; set; }
    }
}