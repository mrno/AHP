using GALibrary;
using GALibrary.Complementos;
using GeneticResearcher.Command;
using GeneticResearcher.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ViewModels
{
    public class OperatorControlViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly ReadOnlyCollection<OperatorViewModel> _allOperators; 

        #endregion // Fields
        
        #region Constructor
        
        public OperatorControlViewModel()
        {
            _allOperators = GetAssemblyOperators();
            SelectedOperators = new ObservableCollection<OperatorViewModel>();

            AddCommand = new RelayCommand<OperatorViewModel>(OnAddOperator, CanAddRemoveOperator);
            RemoveCommand = new RelayCommand<OperatorViewModel>(OnRemoveOperator, CanAddRemoveOperator);
            AscendCommand = new RelayCommand<OperatorViewModel>(OnAscendOperator, CanAscendOperator);
            DescendCommand = new RelayCommand<OperatorViewModel>(OnDescendOperator, CanDescendOperator);
        }

        #endregion // Constructor
        
        #region Properties

        public string SelectedOperatorsNames
        {
            get
            {
                var operators = "";
                foreach (var viewModel in SelectedOperators)
                {
                    operators += viewModel.Name + ">";
                }
                return operators.Substring(0, operators.Length - 1);
            }
        }

        public OperatorViewModel SelectedOperator { get; set; }

        public IEnumerable<OperatorViewModel> AvailableOperators
        {
            get { return _allOperators.Where(x => !SelectedOperators.Contains(x)); }
        }

        public ObservableCollection<OperatorViewModel> SelectedOperators { get; set; }

        #endregion // Properties

        #region Commands

        public RelayCommand<OperatorViewModel> AddCommand { get; set; }
        private void OnAddOperator(OperatorViewModel selectedOperator)
        {
            SelectedOperators.Add(selectedOperator);
            OnPropertyChanged("AvailableOperators");

            SelectedOperator = selectedOperator;
            OnPropertyChanged("SelectedOperator");
        }

        public RelayCommand<OperatorViewModel> RemoveCommand { get; set; }
        private void OnRemoveOperator(OperatorViewModel selectedOperator)
        {
            SelectedOperators.Remove(selectedOperator);
            OnPropertyChanged("AvailableOperators");

            SelectedOperator = SelectedOperators.FirstOrDefault();
            OnPropertyChanged("SelectedOperator");
        }

        public RelayCommand<OperatorViewModel> AscendCommand { get; set; }
        private void OnAscendOperator(OperatorViewModel selectedOperator)
        {
            var oldIndex = SelectedOperators.IndexOf(selectedOperator);
            var previousOperator = SelectedOperators.ElementAt(oldIndex - 1);
            
            SelectedOperators.Remove(selectedOperator);
            SelectedOperators.Remove(previousOperator);

            SelectedOperators.Insert(oldIndex - 1, selectedOperator);
            SelectedOperators.Insert(oldIndex, previousOperator);

            SelectedOperator = selectedOperator;
            OnPropertyChanged("SelectedOperator");
        }

        public RelayCommand<OperatorViewModel> DescendCommand { get; set; }
        private void OnDescendOperator(OperatorViewModel selectedOperator)
        {
            var oldIndex = SelectedOperators.IndexOf(selectedOperator);
            var nextOperator = SelectedOperators.ElementAt(oldIndex + 1);

            SelectedOperators.Remove(selectedOperator);
            SelectedOperators.Remove(nextOperator);

            SelectedOperators.Insert(oldIndex, nextOperator);
            SelectedOperators.Insert(oldIndex + 1, selectedOperator);
            
            SelectedOperator = selectedOperator;
            OnPropertyChanged("SelectedOperator");
        }

        private bool CanAddRemoveOperator(OperatorViewModel selectedOperator)
        {
            return selectedOperator != null;
        }

        private bool CanAscendOperator(OperatorViewModel selectedOperator)
        {
            return CanAddRemoveOperator(selectedOperator) 
                && SelectedOperators.Count > 1 
                && SelectedOperators.IndexOf(selectedOperator) != 0; 
            // solo se puede reordenar con 2+ elementos
        }

        private bool CanDescendOperator(OperatorViewModel selectedOperator)
        {
            return CanAddRemoveOperator(selectedOperator)
                && SelectedOperators.Count > 1
                && SelectedOperators.IndexOf(selectedOperator) != (SelectedOperators.Count - 1);
            // solo se puede reordenar con 2+ elementos
        }

        #endregion

        #region Methods

        private static ReadOnlyCollection<OperatorViewModel> GetAssemblyOperators()
        {
            var operators = FacadeGAModule.ObtenerElementosAG(TipoElementoAG.Operador);
            var lista = from op in operators
                        select new OperatorViewModel(op);
            
            return new ReadOnlyCollection<OperatorViewModel>(lista.OrderBy(x => x.DisplayName).ToList());
        }
        
        #endregion // Methods
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
