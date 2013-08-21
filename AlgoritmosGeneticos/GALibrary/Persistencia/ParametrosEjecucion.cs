using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.Persistencia
{
    public abstract class ParametrosEjecucion
    {
        public virtual int Id { get; set; }
        public virtual bool ParametrosPorDefecto { get; set; }
    }
}
