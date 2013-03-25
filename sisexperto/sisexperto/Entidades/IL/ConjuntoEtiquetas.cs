using sisExperto.Entidades;
using System.Collections.Generic;

namespace sisexperto.Entidades
{
    public class ConjuntoEtiquetas
    {
        public int ConjuntoEtiquetasId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }

        public int Token { get; set; }
        //la propiedad tipo hace referencia si el conjunto de etiquetas en base o virtual.
        //la base son aquellas que reflejan las valoraciones reales de los expertos.
        //la virtual es la extrapolada y normalizada que se usa en los calculos de IL.
        public int Tipo { get; set; }
        public virtual ICollection<Etiqueta> Etiquetas { get; set; }

        public int? ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }

    }
}