using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades
{
    public class ValoracionIL
    {

        public int ValoracionILId { get; set;  }
        public virtual ConjuntoEtiquetas ConjuntoEtiquetas { get; set; }
        public virtual List<AlternativaIL> AlternativasIL { get; set; }


    }
}
