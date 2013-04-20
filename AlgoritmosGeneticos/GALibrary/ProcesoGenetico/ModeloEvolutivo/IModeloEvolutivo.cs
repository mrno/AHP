using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.ProcesoGenetico.Operadores.Abstracto;

namespace GALibrary.ProcesoGenetico.ModeloEvolutivo
{
    public interface IModeloEvolutivo
    {
        IOperador Selector { get; set; }
        IOperador Cruzador { get; set; }
        IOperador Mutador { get; set; }
        Poblacion ObtenerSiguienteGeneracion(Poblacion poblacion);
        bool Parada { get; }
    }
}
