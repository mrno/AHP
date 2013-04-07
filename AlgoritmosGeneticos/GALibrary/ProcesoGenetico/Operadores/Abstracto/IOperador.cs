using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Abstracto
{
    public interface IOperador
    {
        IEnumerable<Individuo> Operar(Poblacion poblacion, int cantidadIndividuos);
    }
}
