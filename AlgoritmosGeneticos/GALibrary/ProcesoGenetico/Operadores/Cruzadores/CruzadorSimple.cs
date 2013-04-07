using System;
using System.Linq;
using System.Collections.Generic;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Cruzadores
{
    public class CruzadorSimple : CruzadorAbstracto
    {
        public override IEnumerable<Individuo> Operar(Poblacion poblacion, int cantidadHijos)
        {
            var resultado = new List<Individuo>();
            var total = poblacion.Individuos.Count;

            for (var i = 0; i < cantidadHijos; i+= 2)
            {
                var padre = poblacion.Individuos.ElementAt(i % total);
                var madre = poblacion.Individuos.ElementAt((i + 1) % total);

                resultado.AddRange(ObtenerHijos(padre, madre).ToList());
            }
            return resultado;
        }

        private IEnumerable<Individuo> ObtenerHijos(Individuo padre, Individuo madre)
        {
            var hijo1 = padre.Clone() as Individuo;
            var hijo2 = padre.Clone() as Individuo;

            var cantidadCaracteristicas = padre.Estructura.Length;

            var corte = Random.Next(1, cantidadCaracteristicas);

            for (var i = 0; i < corte; i++)
            {
                hijo1.Estructura[i] = madre.Estructura[i];
            }

            for (var i = corte; i < cantidadCaracteristicas; i++)
            {
                hijo2.Estructura[i] = madre.Estructura[i];
            }

            return new List<Individuo>() {hijo1, hijo2};
        }
    }
}
