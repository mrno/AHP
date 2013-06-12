using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Complementos;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.ConvergenciaPoblacion
{
    [ElementoAG(TipoElementoAG.ConvergenciaPoblacion, "ConvergenciaEstructura")]
    public class ConvergenciaEstructura : IConvergenciaPoblacion
    {
        public double CalcularConvergencia(Poblacion poblacion)
        {
            var cantidadIndividuos = poblacion.Individuos.Count;
            var iguales = (from c in poblacion.Individuos
                           group c by c.Aptitud
                               into g
                               let cant = g.Count()
                               select cant).Max();
            return (double)iguales / cantidadIndividuos;
        }
    }
}
