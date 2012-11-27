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

        public virtual ICollection<Etiqueta> Etiquetas { get; set; }
    }
}