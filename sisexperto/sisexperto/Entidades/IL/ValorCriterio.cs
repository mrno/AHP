using System;
using System.ComponentModel.DataAnnotations;

namespace sisexperto.Entidades.IL
{
    public class ValorCriterio : ICloneable
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ValorCriterioId { get; set; }
        public double ValorILNumerico { get; set; }
        public string ValorILLinguistico { get; set; }
        [Required]
        public virtual AlternativaIL AlternativaIL { get; set; }

        #region Implementation of ICloneable

        public object Clone()
        {
            return new ValorCriterio
                       {
                           Nombre = Nombre,
                           Descripcion = Descripcion,
                           ValorILLinguistico = ValorILLinguistico,
                           ValorILNumerico = ValorILNumerico
                       };
        }

        #endregion
    }
}
