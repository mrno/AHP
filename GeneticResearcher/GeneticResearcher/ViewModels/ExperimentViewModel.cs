using GALibrary.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticResearcher.Common;

namespace GeneticResearcher.ViewModels
{
    public class ExperimentViewModel
    {
        #region Fields

        private readonly SesionExperimentacion _session;

        #endregion

        #region Constructors

        public ExperimentViewModel(SesionExperimentacion session)
        {
            _session = session;
        }

        #endregion

        #region Properties

        public string EvolutiveModel
        {
            get { return "Modelo Evolutivo: " + _session.ModeloEvolutivo; }
        }

        public string Selection
        {
            get
            {
                return "Operadores: " + _session.Seleccion
                       + "\nPorcentaje: " + _session.PorcentajeSeleccion.ToString("0.0%");
            }
        }

        public string Crossover
        {
            get
            {
                return "Operadores: " + _session.Cruza
                       + "\nPorcentaje: " + _session.PorcentajeCruza.ToString("0.0%");
            }
        }

        public string Mutation
        {
            get
            {
                return "Operadores: " + _session.Mutacion
                       + "\nProbabilidad por:" + _session.ProbabilidadMutacion
                       + "\nPorcentaje Máximo: " + _session.PorcentajeMaximoMutacion.ToString("0.0%")
                       + "\nPorcentaje Mínimo: " + _session.PorcentajeMinimoMutacion.ToString("0.0%")
                       + "\nIncremento Porcentaje: " + _session.CrecimientoPorcentajeMutacion.ToString("0.0000%");
            }
        }

        public string StopCondition
        {
            get { return _session.CondicionParada; }
        }

        public string Individuals
        {
            get { return _session.Individuos.ToString(); }
        }

        public string Convergence
        {
            get { return _session.ConvergenciaPoblacion; }
        }

        public string FitnessFunction
        {
            get { return _session.FuncionAptitud; }
        }

        public bool HasFitnessFunction
        {
            get { return _session.FuncionAptitud != null; }
        }

        #endregion
    }
}
