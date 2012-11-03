using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisexperto.Entidades
{
    [Table("Expertos")]
    public class Experto
    {
        public int ExpertoId { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public virtual ICollection<Proyecto> ProyectosCreados { get; set; }

        public virtual ICollection<Proyecto> ProyectosAsignados { get; set; }
    }
}
