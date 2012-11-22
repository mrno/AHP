using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sisExperto.Entidades;

namespace sisexperto.Entidades
{
    public class AlternativaMatriz
    {
        public int AlternativaMatrizId { get; set; }
        public bool Consistencia { get; set; }

        public int CriterioId { get; set; }
        public virtual Criterio Criterio { get; set; }

        public virtual ExpertoEnProyecto ExpertoEnProyecto { get; set; }

        public virtual ICollection<AlternativaFila> FilasAlternativa { get; set; }
    }
}
