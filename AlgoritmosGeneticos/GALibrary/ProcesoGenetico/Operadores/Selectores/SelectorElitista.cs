using System.Collections.Generic;
using System.Linq;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.Complementos;

namespace GALibrary.ProcesoGenetico.Operadores.Selectores
{
    [ElementoAG(TipoElementoAG.Operador, "SelectorElitista")]
    public class SelectorElitista : SelectorAbstracto
    {
        public override IEnumerable<Individuo> Operar(Poblacion poblacion, int nroSeleccionados)
        {
            return (from c in poblacion.Individuos 
                    orderby c.Aptitud descending
                    select c).Take(nroSeleccionados);
        }
    }
}
