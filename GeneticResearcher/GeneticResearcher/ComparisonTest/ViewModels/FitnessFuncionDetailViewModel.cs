using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ComparisonTest.ViewModels
{
    public class FitnessFuncionDetailViewModel
    {
        #region Fields

        private int _dimension;
        private DetailedMatrixViewModel _matrix;
        private MatrixViewModel _distance;

        #endregion

        #region Constructors

        public FitnessFuncionDetailViewModel(int dimension)
        {
            _dimension = dimension;
        }

        #endregion

        #region Properties

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

        #endregion
    }
}
