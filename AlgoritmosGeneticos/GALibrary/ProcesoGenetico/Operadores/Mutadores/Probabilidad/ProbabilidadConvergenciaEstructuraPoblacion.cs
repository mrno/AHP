using GALibrary.ProcesoGenetico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadConvergenciaEstructuraPoblacion : ProbabilidadConvergenciaAbstracta
    {
        public ProbabilidadConvergenciaEstructuraPoblacion(double probabilidadMenor, double probabilidadMayor)
            : base(probabilidadMenor, probabilidadMayor)
        {
        }

        public override double CalcularProbabilidad(Poblacion poblacion)
        {
            var cantidadIndividuos = poblacion.Individuos.Count;
            var iguales = (from c in poblacion.Individuos
                           group c by c.Estructura
                           into g
                           let cant = g.Count()
                           select cant).Max();

            return (ProbabilidadMayor - ProbabilidadMenor)*((double)iguales/cantidadIndividuos) + ProbabilidadMenor;
        }
    }
}
