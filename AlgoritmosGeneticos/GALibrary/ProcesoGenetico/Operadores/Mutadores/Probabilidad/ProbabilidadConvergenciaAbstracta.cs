using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public abstract class ProbabilidadConvergenciaAbstracta : IProbabilidadMutacion
    {
        protected double ProbabilidadMayor;
        protected double ProbabilidadMenor;

        protected ProbabilidadConvergenciaAbstracta(double probabilidadMenor, double probabilidadMayor)
        {
            ProbabilidadMayor = probabilidadMayor;
            ProbabilidadMenor = probabilidadMenor;
        }

        public abstract double CalcularProbabilidad(Poblacion poblacion);
    }
}
