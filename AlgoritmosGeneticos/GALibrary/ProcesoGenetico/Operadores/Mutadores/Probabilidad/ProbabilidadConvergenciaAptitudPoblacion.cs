using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadConvergenciaAptitudPoblacion : ProbabilidadConvergenciaAbstracta
    {
        public ProbabilidadConvergenciaAptitudPoblacion(double probabilidadMenor, double probabilidadMayor)
            : base(probabilidadMenor, probabilidadMayor)
        {
        }

        public override double CalcularProbabilidad(Poblacion poblacion)
        {
            return (ProbabilidadMayor - ProbabilidadMenor)*poblacion.ConvergenciaAptitud() + ProbabilidadMenor;
        }
    }
}
