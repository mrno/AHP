using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisexperto.Entidades
{
    [Table("Proyectos")]
    public class Proyecto
    {
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Objetivo { get; set; }

        public int CreadorId { get; set; }
        public virtual Experto Creador { get; set; }

        public virtual ICollection<ExpertoEnProyecto> ExpertosAsignados { get; set; }

        public virtual ICollection<Criterio> Criterios { get; set; }

        public virtual ICollection<Alternativa> Alternativas { get; set; }

        public virtual ICollection<ValoracionCriteriosPorExperto> CriteriosValoradosPorExpertos { get; set; }

    }
}
