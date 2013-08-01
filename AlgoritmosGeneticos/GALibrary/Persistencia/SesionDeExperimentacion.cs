using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.Persistencia
{
    public class SesionDeExperimentacion
    {
        public virtual int Id { get; set; }
        public virtual ICollection<ParametrosEjecucion> ParametrosEjecucion { get; set; }
        public virtual ICollection<Correccion> Correcciones { get; set; } 

        public void EjecutarExperimentos(ICollection<ObjetoMatriz> matrices)
        {
            
        }
    }
}
