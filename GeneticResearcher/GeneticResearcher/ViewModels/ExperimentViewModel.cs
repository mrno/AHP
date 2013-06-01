using GALibrary.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ViewModels
{
    public class ExperimentViewModel
    {
        #region Fields

        private SesionExperimentacion _sesion;

        #endregion

        #region Constructors

        public ExperimentViewModel(SesionExperimentacion sesion)
        {
            _sesion = sesion;
        }

        #endregion

        #region Properties

        public string EvolutiveModel
        {
            get { return "Modelo Evolutivo: " + _sesion.ModeloEvolutivo; }
        }

        public string Selection
        {
            get
            {
                return "Operadores: " + _sesion.Seleccion
                       + "\nPorcentaje: " + _sesion.PorcentajeSeleccion.ToString("0.0%");
            }
        }

        public string Crossover
        {
            get
            {
                return "Operadores: " + _sesion.Cruza
                       + "\nPorcentaje: " + _sesion.PorcentajeCruza.ToString("0.0%");
            }
        }

        public string Mutation
        {
            get
            {
                return "Operadores: " + _sesion.Mutacion
                       + "\nProbabilidad por:" + _sesion.ProbabilidadMutacion
                       + "\nPorcentaje Máximo: " + _sesion.PorcentajeMaximoMutacion.ToString("0.0%")
                       + "\nPorcentaje Mínimo: " + _sesion.PorcentajeMinimoMutacion.ToString("0.0%")
                       + "\nIncremento Porcentaje: " + _sesion.CrecimientoPorcentajeMutacion.ToString("0.0000%");
            }
        }

        public string StopCondition
        {
            get { return _sesion.CondicionParada; }
        }

        public string Individuals
        {
            get { return _sesion.Individuos.ToString(); }
        }

        public string Convergence
        {
            get { return _sesion.ConvergenciaPoblacion; }
        }

        public string FitnessFunction
        {
            get { return _sesion.FuncionAptitud; }
        }

        public bool HasFitnessFunction
        {
            get { return _sesion.FuncionAptitud != null; }
        }

        #endregion
    }
}
