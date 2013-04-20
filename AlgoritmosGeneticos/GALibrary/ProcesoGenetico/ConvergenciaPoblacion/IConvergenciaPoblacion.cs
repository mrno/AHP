using GALibrary.ProcesoGenetico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.ProcesoGenetico.ConvergenciaPoblacion
{
    public interface IConvergenciaPoblacion
    {
        double CalcularConvergencia(Poblacion poblacion);
    }
}
