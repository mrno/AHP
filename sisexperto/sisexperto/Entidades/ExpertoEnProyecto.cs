using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sisexperto.Entidades
{
    [Table("ExpertosPonderadosEnProyectos")]
    public class ExpertoEnProyecto
    {
        [Key, Column(Order = 0)]
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
        [Key, Column(Order = 1)]
        public int ExpertoId { get; set; }
        public Experto Experto { get; set; }

        public double Ponderacion { get; set; }
    }
}
