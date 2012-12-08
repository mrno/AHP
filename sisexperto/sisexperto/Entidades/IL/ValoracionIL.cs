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
        public virtual ICollection<AlternativaIL> AlternativasIL { get; set; }


    }
}
