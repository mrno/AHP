using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisExperto.Entidades
{
    [Table("ValoracionCriteriosPorExpertos")]
    public class ValoracionCriteriosPorExperto
    {
        public int ValoracionCriteriosPorExpertoId { get; set; }
        public bool Consistencia { get; set; }

        public int ExpertoId { get; set; }
        public virtual Experto Experto { get; set; }

        public int CriterioId { get; set; }
        public virtual Criterio Criterio { get; set; }

        public virtual ICollection<ComparacionCriterio> ComparacionCriterios { get; set; }
    }
}
