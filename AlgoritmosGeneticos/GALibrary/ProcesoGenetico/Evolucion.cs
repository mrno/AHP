using GALibrary.Complementos;
using GALibrary.Persistencia;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.ProcesoGenetico.ModeloEvolutivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.ProcesoGenetico
{
    public class Evolucion
    {
        private IModeloEvolutivo _modeloEvolutivo;

        private Estructura _estructuraBase;

        private SesionExperimentacion _sesionExperimentacion;

        public Evolucion(ObjetoMatriz matrizIncompleta, SesionExperimentacion sesionExperimentacion)
        {
            _estructuraBase = new Estructura(matrizIncompleta);
            _sesionExperimentacion = sesionExperimentacion;
        }

        public ResultadoExperimento Evolucionar()
        {
            var cantidadIteraciones = int.Parse(_sesionExperimentacion.CondicionParada.Split('&')
                                                    .First(x => x.Contains("Iteraciones")).Split(':')[1]);
            var poblacion = Poblacion.GenerarPoblacionInicial
                (_sesionExperimentacion.Individuos,
                 cantidadIteraciones,
                 _estructuraBase,
                 _sesionExperimentacion.FuncionAptitud,
                 _sesionExperimentacion.ConvergenciaPoblacion);

            _modeloEvolutivo = (new ModeloEvolutivoFactory()).CreateInstance(_sesionExperimentacion.ModeloEvolutivo);
            _modeloEvolutivo.ConfigurarModelo(_sesionExperimentacion);
            _modeloEvolutivo.RegistrarInicioExperimento(poblacion);
            while (!_modeloEvolutivo.Parada)
            {
                poblacion = _modeloEvolutivo.ObtenerSiguienteGeneracion(poblacion);
            }

            _modeloEvolutivo.RegistrarFinExperimento();
            
            return _modeloEvolutivo.ExperimentoResultado;
        }
    }
}
