using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisexperto.Entidades
{
    [Table("ValoracionAlternativasPorCriterioExperto")]
    public class ValoracionAlternativasPorCriterioExperto
    {
        public int ValoracionAlternativasPorCriterioExpertoId { get; set; }
        public bool Consistencia { get; set; }

        public int ExpertoId { get; set; }
        public virtual Experto Experto { get; set; }

        //public int CriterioId { get; set; }
        //public virtual Criterio Criterio { get; set; }

        public int AlternativaId { get; set; }
        public virtual Alternativa Alternativa { get; set; }

        public virtual ICollection<ComparacionAlternativa> ComparacionAlternativasPorCriterio { get; set; }

    }
}
