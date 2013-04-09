using GALibrary.Complementos;
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
        private Poblacion _poblacionInicial;
        private IModeloEvolutivo _modeloEvolutivo;

        private Estructura _estructuraBase;
        private Estructura _estructuraObjetivo;

        public Evolucion(Estructura estructuraBase, Estructura estructuraObjetivo, int cantidadIndividuos)
        {
            _estructuraBase = estructuraBase;
            _estructuraObjetivo = estructuraObjetivo;

            _poblacionInicial = Poblacion.GenerarPoblacionInicial
                (cantidadIndividuos, _estructuraBase, _estructuraObjetivo, "FuncionAptitudConsistencia");
        }

        public Individuo Evolucionar(string nombreModeloEvolutivo)
        {
            _modeloEvolutivo = (new ModeloEvolutivoFactory()).CreateInstance(nombreModeloEvolutivo);
            var poblaciones = new List<Poblacion>();
            var poblacion = _poblacionInicial;
            poblaciones.Add(poblacion);

            do
            {
                poblacion = _modeloEvolutivo.ObtenerSiguienteGeneracion(poblacion);
                poblaciones.Add(poblacion);
            } while (!_modeloEvolutivo.Parada);

            return poblacion.MejorIndividuo;
        }
    }
}
