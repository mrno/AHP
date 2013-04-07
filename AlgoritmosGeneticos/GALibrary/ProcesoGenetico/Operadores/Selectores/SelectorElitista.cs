using System.Collections.Generic;
using System.Linq;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Selectores
{
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
