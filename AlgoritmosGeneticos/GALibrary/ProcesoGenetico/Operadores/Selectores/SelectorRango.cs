using System.Collections.Generic;
using System.Linq;
using GALibrary.Complementos;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Selectores
{
    [ElementoAG(TipoElementoAG.Operador, "SelectorRango")]
    public class SelectorRango : SelectorAbstracto
    {
        public override IEnumerable<Individuo> Operar(Poblacion poblacion, int nroSeleccionados)
        {
            var seleccionados = new List<Individuo>();

            var probabilidadAcumulada = CalcularProbabilidadAcumulada(poblacion);

            for (var i = 0; i < nroSeleccionados; i++)
            {
                var aux = Random.NextDouble();
                for(var j = 0; j < probabilidadAcumulada.Count(); j++)
                {
                    if (probabilidadAcumulada[j] >= aux)
                    {
                        seleccionados.Add(poblacion.Individuos.ElementAt(i));
                        break;
                    }
                }
            }
            return seleccionados;
        }

        private double[] CalcularProbabilidadAcumulada(Poblacion poblacion)
        {
            var cantidad = poblacion.Individuos.Count();

            var aptitudTotal = (from c in poblacion.Individuos select c.Aptitud).Sum();

            var probabilidadAcumulada = new double[cantidad];

            for (var i = 0; i < cantidad; i++)
            {
                probabilidadAcumulada[i] = poblacion.Individuos.ElementAt(i).Aptitud / aptitudTotal;
           
                if (i > 0) probabilidadAcumulada[i] += probabilidadAcumulada[i - 1];
            }

            return probabilidadAcumulada;
        }
    }



}
