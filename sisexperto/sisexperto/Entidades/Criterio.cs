using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades
{
    public class Criterio
    {
        public int CriterioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        //posible valor de ponderación en proyecto IL

        public virtual ICollection<ValoracionAlternativasPorCriterioExperto> ValoracionAlternativasPorExperto { get; set; }

        //public virtual ICollection<ComparacionAlternativa> ComparacionAlternativas { get; set; }

    }
}
