using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace sisexperto.Entidades.IL
{
    public class AlternativaIL : ICloneable
    {
        public int AlternativaILId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Valorada { get; set; }
        [Required]
        public virtual ValoracionIL ValoracionIL { get; set; }
        public virtual ICollection<ValorCriterio> ValorCriterios { get; set; }

        #region Implementation of ICloneable

        public object Clone()
        {
            return new AlternativaIL
                       {
                           Nombre = Nombre,
                           Descripcion = Descripcion,
                           Valorada = Valorada,
                           ValorCriterios = (from c in ValorCriterios
                                             select c.Clone() as ValorCriterio).ToList()
                       };
        }

        #endregion
    }
}
