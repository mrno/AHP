using System;
using System.Collections.Generic;
using System.Linq;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Selectores
{
    public class SelectorRuleta : SelectorAbstracto
    {
        public override IEnumerable<Individuo> Operar(Poblacion poblacion, int nroSeleccionados)
        {
            var seleccionados = new List<Individuo>();

            //TODO: ver como hacer el tema de la cantidad de ranuras
            int nroRanuras = 1000;
            
            var ranurasAcumuladas = CalcularRanurasAcumulada(poblacion, nroRanuras);
            var ultimaRanura = ranurasAcumuladas.Last();
            for (int i = 0; i < nroSeleccionados; i++)
            {
                var aux = Random.Next(0, ultimaRanura + 1);
                for (int j = 0; j < ranurasAcumuladas.Count(); j++)
                {
                    if (ranurasAcumuladas[j] >= aux)
                    {
                        seleccionados.Add(poblacion.Individuos.ElementAt(i).Clone() as Individuo);
                        break;
                    }
                }
            }
            return seleccionados;
        }

        private int[] CalcularRanurasAcumulada(Poblacion poblacion, int ranuras)
        {
            var cantidad = poblacion.Individuos.Count();

            var aptitudTotal = (from c in poblacion.Individuos
                                   select c.Aptitud).Sum();

            var ranurasAcumuladas = new int[cantidad];

            for (var i = 0; i < cantidad; i++)
            {
                ranurasAcumuladas[i] = (int) Math.Round(ranuras * poblacion.Individuos.ElementAt(i).Aptitud / aptitudTotal);

                if (i > 0) ranurasAcumuladas[i] += ranurasAcumuladas[i - 1];
            }

            return ranurasAcumuladas;
        }
    }
}
