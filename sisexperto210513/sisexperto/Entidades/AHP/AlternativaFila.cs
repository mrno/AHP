using System.Collections.Generic;
using sisExperto.Entidades;

namespace sisexperto.Entidades.AHP
{
    public class AlternativaFila
    {
        public int AlternativaFilaId { get; set; }

        public int AlternativaId { get; set; }
        public virtual Alternativa Alternativa { get; set; }

        public virtual ICollection<AlternativaCelda> CeldasAlternativas { get; set; }

    }
}