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

        private ReadOnlyCollection<FitnessViewModel> _fitnessFunctions;

        private ReadOnlyCollection<OptionViewModel<string>> _firstFitnessFunctionOptionList;
        private ReadOnlyCollection<OptionViewModel<string>> _secondFitnessFunctionOptionList;

        private DetailedMatrixViewModel _inputMatrix;

        private ReadOnlyCollection<OptionViewModel<int>> _dimensions;
        private int _dimension;
        
        
        #endregion // Fields

        #region Constructor

        public ComparisonTestViewModel()
        {
            _inputMatrix = new DetailedMatrixViewModel(4);
            FitnessFuncionFirst = new FitnessFuncionDetailViewModel(4);
            FitnessFuncionSecond = new FitnessFuncionDetailViewModel(4);
            //ExperimentSummary = new ExperimentViewModel(new SesionExperimentacion());
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
                    Matrix.Matrix.Matrix = new double[_dimension,_dimension];
                    FitnessFuncionFirst.Matrix.Matrix.Matrix = new double[_dimension, _dimension];
                    FitnessFuncionSecond.Matrix.Matrix.Matrix = new double[_dimension, _dimension];

                    FitnessFuncionFirst.Distance.Matrix = new double[_dimension, _dimension];
                    FitnessFuncionSecond.Distance.Matrix = new double[_dimension, _dimension];
                    //Matrix = new double[_dimension, _dimension];
                    //OnPropertyChanged("Matriz");
                    //OnPropertyChanged("Rows");
                }
            }
        }

        public DetailedMatrixViewModel Matrix
        {
            get { return _inputMatrix ?? (_inputMatrix = new DetailedMatrixViewModel(4)); }
        }

        public FitnessFuncionDetailViewModel FitnessFuncionFirst { get; set; }
        public FitnessFuncionDetailViewModel FitnessFuncionSecond { get; set; }

        public ExperimentViewModel ExperimentSummary { get; private set; }

        #endregion // Properties

        #region Methods

        #endregion // Methods

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members


    }
}
