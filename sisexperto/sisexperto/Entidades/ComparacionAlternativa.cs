using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades
{
    public class ComparacionAlternativa
    {
        public int ComparacionAlternativaId { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public double Valor { get; set; }

        //public int ProyectoId { get; set; }
        //public virtual Proyecto Proyecto { get; set; }

        //public int ExpertoId { get; set; }
        //public virtual Experto Experto { get; set; }
        
        //public int CriterioId { get; set; }
        //public virtual Criterio Criterio { get; set; }
       
        public int AlternativaId { get; set; }
        public virtual Alternativa Alternativa { get; set; }

        //public int Alternativa2Id { get; set; }
        //public virtual Alternativa Alternativa2 { get; set; }
    }
}
