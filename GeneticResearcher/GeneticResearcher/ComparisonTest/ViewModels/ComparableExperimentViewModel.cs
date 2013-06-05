using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Persistencia;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.ComparisonTest.ViewModels
{
    public class ComparableExperimentViewModel
    {
        #region Fields

        private int _dimension;
        private DetailedMatrixViewModel _matrix;
        private MatrixViewModel _distance;

        #endregion

        #region Constructors

        public ComparableExperimentViewModel(int dimension, string displayName)
        {
            _dimension = dimension;
            DisplayName = displayName;
            ExperimentSummary = new ExperimentViewModel(new SesionExperimentacion());
        }

        #endregion

        #region Properties

        public string DisplayName { get; set; }

        public DetailedMatrixViewModel Matrix
        {
            get { return _matrix ?? (_matrix = new DetailedMatrixViewModel(_dimension)); }
            private set { _matrix = value; }
        }
        public MatrixViewModel Distance
        {
            get { return _distance ?? (_distance = new MatrixViewModel(_dimension)); }
            private set { _distance = value; }
        }
        public ExperimentViewModel ExperimentSummary { get; private set; }

        #endregion
    }
}
