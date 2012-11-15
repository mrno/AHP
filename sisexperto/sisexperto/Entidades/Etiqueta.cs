using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades
{
    
    public class Etiqueta
    {
       
        public int EtiquetaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        //public int ConjuntoEtiquetasId { get; set; }
        //public virtual ConjuntoEtiquetas ConjuntoEtiquetas { get; set; }

    }
}
