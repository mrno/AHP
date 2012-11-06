using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sisExperto.Entidades
{
    [Table("ExpertosPonderadosEnProyectos")]
    public class ExpertoEnProyecto
    {
        [Key, Column(Order = 0)]
        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        [Key, Column(Order = 1)]
        public int ExpertoId { get; set; }
        public virtual Experto Experto { get; set; }

        public double Ponderacion { get; set; }
        public double Peso { get; set; }

        public virtual ValoracionCriteriosPorExperto ValoracionCriteriosPorExperto { get; set; }
        public virtual ICollection<ValoracionAlternativasPorCriterioExperto> ValoracionAlternativasPorCriterioExperto { get; set; }

    }
}
