
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisExperto.Entidades
{

    public class AlternativaFila
    {
        public int AlternativaFilaId { get; set; }
        
        public int AlternativaId { get; set; }
        public virtual Alternativa Alternativa { get; set; }

        public virtual ICollection<AlternativaCelda> CeldasAlternativas { get; set; }
    }
}
