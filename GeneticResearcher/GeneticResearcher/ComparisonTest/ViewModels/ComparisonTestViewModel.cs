using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using GALibrary.Persistencia;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.ComparisonTest.ViewModels
{
    public class ComparisonTestViewModel: INotifyPropertyChanged
    {
        #region Fields

        private MatrixViewModel _inputMatrix;

        private ReadOnlyCollection<OptionViewModel<int>> _dimensions;
        private int _dimension;
        
        
        #endregion // Fields

        #region Constructor

        public ComparisonTestViewModel()
        {
            _inputMatrix = new MatrixViewModel(4);
            ComparableExperimentFirst = new ComparableExperimentViewModel(4, "Experimento 1");
            ComparableExperimentSecond = new ComparableExperimentViewModel(4, "Experimento 2");
            CommonExperimentSummary = new ExperimentViewModel(new SesionExperimentacion());
        }

        #endregion // Constructor

        #region Properties


        public IEnumerable<OptionViewModel<int>> Dimensions
        {
            get
            {
                if (_dimensions == null)
                {
                    var dimension = new List<OptionViewModel<int>>
                                     {
                                         new OptionViewModel<int>("4", 4),
                                         new OptionViewModel<int>("5", 5),
                                         new OptionViewModel<int>("6", 6),
                                         new OptionViewModel<int>("7", 7),
                                         new OptionViewModel<int>("8", 8),
                                         new OptionViewModel<int>("9", 9)
                                     };

                    _dimensions = new ReadOnlyCollection<OptionViewModel<int>>(dimension);
                }
                return _dimensions;
            }
        }

        public OptionViewModel<int> SelectedDimension
        {
            get { return new OptionViewModel<int>(_dimension.ToString(), _dimension); }
            set
            {
                var selectedDimension = value.GetValue();
                if (_dimension != selectedDimension)
                {
                    _dimension = selectedDimension;
                    Matrix.Matrix = new double[_dimension,_dimension];
                    ComparableExperimentFirst.Matrix.Matrix.Matrix = new double[_dimension, _dimension];
                    ComparableExperimentSecond.Matrix.Matrix.Matrix = new double[_dimension, _dimension];

                    ComparableExperimentFirst.Distance.Matrix = new double[_dimension, _dimension];
                    ComparableExperimentSecond.Distance.Matrix = new double[_dimension, _dimension];
                    //Matrix = new double[_dimension, _dimension];
                    //OnPropertyChanged("Matriz");
                    //OnPropertyChanged("Rows");
                }
            }
        }

        public MatrixViewModel Matrix
        {
            get { return _inputMatrix ?? (_inputMatrix = new MatrixViewModel(4)); }
        }

        public ComparableExperimentViewModel ComparableExperimentFirst { get; set; }
        public ComparableExperimentViewModel ComparableExperimentSecond { get; set; }

        public ExperimentViewModel CommonExperimentSummary { get; private set; }

        #endregion // Properties

        #region Methods

        #endregion // Methods

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members


    }
}
