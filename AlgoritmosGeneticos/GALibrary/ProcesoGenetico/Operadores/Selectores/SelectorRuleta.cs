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

            var ranuras = GenerarRanuras(poblacion);

            for (int i = 0; i < nroSeleccionados; i++)
            {
                var aux = Random.Next(0, ranuras.Count);
                seleccionados.Add(ranuras.ElementAt(aux));
            }
            return seleccionados;
        }

        private List<Individuo> GenerarRanuras(Poblacion poblacion)
        {
            var aptitudMinima = poblacion.Individuos.Min(x => x.Aptitud);
            var aptitudMaxima = poblacion.Individuos.Max(x => x.Aptitud);

            if (Math.Round(aptitudMaxima/aptitudMinima) == 1.0)
            {
                return poblacion.Individuos;
            }

            var resultado = new List<Individuo>();

            foreach (var individuo in poblacion.Individuos)
            {
                var ranurasAsignadas = Math.Round(individuo.Aptitud/aptitudMinima);
                if(ranurasAsignadas != 1)
                {
                    var asd = 0;
                }
                for (int i = 0; i < ranurasAsignadas; i++)
                {
                    resultado.Add(individuo);
                }
            }

            return resultado;
        }
    }
}
