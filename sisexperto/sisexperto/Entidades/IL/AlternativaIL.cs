using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades
{
    public class AlternativaIL
    {
        public int AlternativaILId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<ValorCriterio> ValorCriterios { get; set; }
    }
}
