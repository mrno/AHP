using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades
{
    public class AlternativaIL
    {
        public int AlternativaILId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Valorada { get; set; }
        [Required]
        public virtual ValoracionIL ValoracionIL { get; set; }
        public virtual ICollection<ValorCriterio> ValorCriterios { get; set; }
    }
}
