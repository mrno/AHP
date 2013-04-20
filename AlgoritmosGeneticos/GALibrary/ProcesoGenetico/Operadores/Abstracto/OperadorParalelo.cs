using System.Collections.Generic;
using System.Linq;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Abstracto
{
    public class OperadorParalelo : OperadorAbstractoMultiple
    {
        public override IEnumerable<Individuo> Operar(Poblacion poblacion, int cantidadIndividuos)
        {
            var _poblacionActual = poblacion.Clone() as Poblacion;

            foreach (var operador in Operadores)
            {
                var nuevosIndividuos = operador.Operar(_poblacionActual, cantidadIndividuos);
                _poblacionActual.Individuos = nuevosIndividuos.ToList();
            }

            return _poblacionActual.Individuos;
        }
    }
}
