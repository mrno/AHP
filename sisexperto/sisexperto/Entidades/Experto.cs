using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sisExperto.Entidades
{
    [Table("Expertos")]
    public class Experto
    {
        public int ExpertoId { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public bool Administrador { get; set; }

        public virtual ICollection<Proyecto> ProyectosCreados { get; set; }
        public virtual ICollection<ExpertoEnProyecto> ProyectosAsignados { get; set; }

        public string ApellidoYNombre { get { return Apellido + ", " + Nombre; } }

        public override string ToString()
        {
            return ApellidoYNombre;
        }
    }
}