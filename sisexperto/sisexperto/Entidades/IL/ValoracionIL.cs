using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades
{
    public class ValoracionIL : Valoracion
    {
        public virtual ConjuntoEtiquetas ConjuntoEtiquetas { get; set; }
        public virtual List<AlternativaIL> AlternativasIL { get; set; }

        public bool valorada()
        {
            int i = 0;
            foreach (var alt in AlternativasIL)
            {
                if (alt.Valorada)
                    i++;
            }
            if (i == AlternativasIL.Count)
                return true;
            else
                return false;
        }

    }
}
