using System.Collections.Generic;
using System.Linq;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Abstracto
{
    public class OperadorSerie : IOperador
    {
        public IEnumerable<OperadorAbstractoSimple> Operadores;
        
        public IEnumerable<Individuo> Operar(Poblacion poblacion, int cantidadIndividuos)
        {
            var poblacionActual = poblacion.Clone() as Poblacion;

            foreach (var operador in Operadores)
            {
                var nuevosIndividuos = operador.Operar(poblacionActual, cantidadIndividuos);
                poblacionActual.Individuos = nuevosIndividuos.ToList();
            }

            return poblacionActual.Individuos;
        }
    }
}
