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
        private readonly IModeloEvolutivo _modeloEvolutivo;
        private readonly ObjetoMatriz _matrizOriginal;
        private readonly Estructura _estructuraBase;
        private readonly ParametrosEjecucionAG _parametrosEjecucionAG;

        public Evolucion(ObjetoMatriz matrizOriginal, ParametrosEjecucionAG parametrosEjecucion)
        {
            _matrizOriginal = matrizOriginal;
            _estructuraBase = new Estructura(matrizOriginal);
            _parametrosEjecucionAG = parametrosEjecucion;
            _modeloEvolutivo = (new ModeloEvolutivoFactory()).CreateInstance(_parametrosEjecucionAG.ModeloEvolutivo);
        }

        public Correccion Evolucionar()
        {
            var cantidadIteraciones = int.Parse(_parametrosEjecucionAG.CondicionParada.Split('&')
                                                    .First(x => x.Contains("Iteraciones")).Split(':')[1]);

            var poblacion = Poblacion.GenerarPoblacionInicial
                (_parametrosEjecucionAG.CantidadIndividuos,
                 cantidadIteraciones,
                 _estructuraBase,
                 _parametrosEjecucionAG.FuncionAptitud,
                 _parametrosEjecucionAG.ConvergenciaPoblacion);

            _modeloEvolutivo.ConfigurarModelo(_parametrosEjecucionAG);
            _modeloEvolutivo.RegistrarInicioExperimento(poblacion, _matrizOriginal);
            while (!_modeloEvolutivo.Parada)
            {
                poblacion = _modeloEvolutivo.ObtenerSiguienteGeneracion(poblacion);
            }

            _modeloEvolutivo.RegistrarFinExperimento();
            
            return _modeloEvolutivo.Correccion;
        }
    }
}
