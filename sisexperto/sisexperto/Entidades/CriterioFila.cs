using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisExperto.Entidades
{
   
    public class CriterioFila
    {
        public int CriterioFilaId { get; set; }
        
        public int CriterioId { get; set; }
        public virtual Criterio Criterio { get; set; }

        public virtual ICollection<CriterioCelda> CeldasCriterios { get; set; }

    }
}
