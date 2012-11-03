using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades
{
    public class ComparacionCriterio
    {
        public int ComparacionCriterioId { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public double Valor { get; set; }

        //public int ProyectoId { get; set; }
        //public virtual Proyecto Proyecto { get; set; }

        //public int ExpertoId { get; set; }
        //public virtual Experto Experto { get; set; }

        public int CriterioId { get; set; }
        public virtual Criterio Criterio { get; set; }

    }
}
