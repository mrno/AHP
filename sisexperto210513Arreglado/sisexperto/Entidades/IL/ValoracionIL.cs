using System;
using System.Collections.Generic;
using System.Linq;

namespace sisexperto.Entidades.IL
{
    public class ValoracionIL : Valoracion, ICloneable
    {
        public virtual ConjuntoEtiquetas ConjuntoEtiquetas { get; set; }
        public virtual ICollection<AlternativaIL> AlternativasIL { get; set; }

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

        #region Implementation of ICloneable

        public object Clone()
        {
            return new ValoracionIL
                       {
                           AlternativasIL = (from c in AlternativasIL
                                             select c.Clone() as AlternativaIL).ToList()
                       };
        }

        #endregion
    }
}
