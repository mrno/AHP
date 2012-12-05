using System.Collections.Generic;
using sisexperto.Entidades;

namespace sisExperto.Entidades
{
    public class CriterioFila
    {
        public int CriterioFilaId { get; set; }

        public int CriterioId { get; set; }
        public virtual Criterio Criterio { get; set; }
        
        //Esta coleccion es para AHP
        public virtual ICollection<CriterioCelda> CeldasCriterios { get; set; }


        //Esta coleccion es para IL
        public virtual ICollection<AlternativaCeldaIL> CeldasAlternativasIL { get; set; }
       
    }
}