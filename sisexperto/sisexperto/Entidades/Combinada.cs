using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sisExperto.Entidades;

namespace sisexperto.Entidades
{
    public class Combinada
    {

        public string ExpertoNombre { get; set; }
        public  Experto Experto { get; set; }
        public string ConjuntoEtiquetasNombre { get; set; }
            public ConjuntoEtiquetas ConjuntoEtiquetas { get; set; }
    }
}
