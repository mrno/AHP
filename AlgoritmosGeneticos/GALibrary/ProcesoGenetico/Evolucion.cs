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
            //Utilidades.Llamadas = 0;
            var poblacion = Poblacion.GenerarPoblacionInicial
                (_sesionExperimentacion.Individuos,
                 _estructuraBase,
                 _sesionExperimentacion.FuncionAptitud,
                 _sesionExperimentacion.ConvergenciaPoblacion);
            //var asd = Utilidades.Llamadas;
            _modeloEvolutivo = (new ModeloEvolutivoFactory()).CreateInstance(_sesionExperimentacion.ModeloEvolutivo);
            _modeloEvolutivo.ConfigurarModelo(_sesionExperimentacion);
            _modeloEvolutivo.RegistrarInicioExperimento(poblacion);
            //Utilidades.CalcularConsistencia(new double[3, 3]);
            while (!_modeloEvolutivo.Parada)
            {
                //asd = Utilidades.Llamadas;
                poblacion = _modeloEvolutivo.ObtenerSiguienteGeneracion(poblacion);
            }

            _modeloEvolutivo.RegistrarFinExperimento();

            //_sesionExperimentacion.Experimentos.Add(_modeloEvolutivo.ExperimentoResultado);

            return _modeloEvolutivo.ExperimentoResultado;
        }
    }
}
