using System.Collections.Generic;
using System.Linq;
using GALibrary.Complementos;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Selectores
{
    [ElementoAG(TipoElementoAG.Operador, "SelectorUniforme")]
    public class SelectorUniforme : SelectorAbstracto
    {
        public override IEnumerable<Individuo> Operar(Poblacion poblacion, int nroSeleccionados)
        {
            var resultado = new List<Individuo>();
            for (int i = 0; i < nroSeleccionados; i++)
            {
                var seleccionado = Random.Next(0, poblacion.Individuos.Count());
                resultado.Add(poblacion.Individuos.ElementAt(seleccionado).Clone() as Individuo);
            }
            return resultado;
        }
    }
}
