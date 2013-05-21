using System.Collections.Generic;
using sisExperto.Entidades;

namespace sisexperto.Entidades.AHP
{
    public class CriterioFila
    {
        public int CriterioFilaId { get; set; }

        public int CriterioId { get; set; }
        public virtual Criterio Criterio { get; set; }
        
        //Esta coleccion es para AHP
        public virtual ICollection<CriterioCelda> CeldasCriterios { get; set; }


     
    }
}