using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.Persistencia
{
    public class ParametrosEjecucionAG : ParametrosEjecucion
    {
        public virtual string ModeloEvolutivo { get; set; }
        public virtual int CantidadIndividuos { get; set; }

        public virtual string OperadoresSeleccion { get; set; }
        public virtual double PorcentajeSeleccion { get; set; }

        public virtual string OperadoresCruza { get; set; }
        public virtual double PorcentajeCruza { get; set; }

        public virtual string OperadoresMutacion { get; set; }
        public virtual string ProbabilidadMutacion { get; set; }
        public virtual double PorcentajeMaximoMutacion { get; set; }
        public virtual double PorcentajeMinimoMutacion { get; set; }
        public virtual double CrecimientoPorcentajeMutacion { get; set; }

        public virtual string CondicionParada { get; set; }
        public virtual string ConvergenciaPoblacion { get; set; }
        public virtual string FuncionAptitud { get; set; }
    }
}
