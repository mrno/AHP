using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.ProcesoGenetico.Operadores.Abstracto;
using GALibrary.Persistencia;

namespace GALibrary.ProcesoGenetico.ModeloEvolutivo
{
    public interface IModeloEvolutivo
    {
        IOperador Selector { get; set; }
        IOperador Cruzador { get; set; }
        IOperador Mutador { get; set; }
        Poblacion ObtenerSiguienteGeneracion(Poblacion poblacion);
        bool Parada { get; }
        ResultadoExperimento ExperimentoResultado { get; }

        void ConfigurarModelo(SesionExperimentacion sesionExperimentacion);
        void RegistrarInicioExperimento();
        void RegistrarFinExperimento();
    }
}
