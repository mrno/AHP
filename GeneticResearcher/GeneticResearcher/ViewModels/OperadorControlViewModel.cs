using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ViewModels
{
    public class OperadorControlViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private ReadOnlyCollection<OperadorViewModel> _availableOperators;
        private ObservableCollection<OperadorViewModel> _selectedOperators;

        #endregion // Fields


        #region Constructor
        
        public OperadorControlViewModel()
        {

        }

        #endregion // Constructor


        #region Properties

        public IEnumerable<OperadorViewModel> AvailableOperators
        {
            get { return _availableOperators ?? (_availableOperators = GetAssemblyOperators()); }
        }

        public IEnumerable<OperadorViewModel> SelectedOperators
        {
            get { return _selectedOperators ?? (_selectedOperators = new ObservableCollection<OperadorViewModel>()); }
        }

        #endregion // Properties


        #region Methods

        private static ReadOnlyCollection<OperadorViewModel> GetAssemblyOperators()
        {
            var lista = new List<OperadorViewModel>();
            lista.Add(new OperadorViewModel("Elitista"));
            lista.Add(new OperadorViewModel("Ruleta"));
            lista.Add(new OperadorViewModel("CruzadorSimple"));
            lista.Add(new OperadorViewModel("MutadorSimple"));
            lista.Add(new OperadorViewModel("Algo"));
            lista.Add(new OperadorViewModel("Algo más"));
            return new ReadOnlyCollection<OperadorViewModel>(lista.OrderBy(x => x.DisplayName).ToList());
        }

        public void AddOperator(OperadorViewModel geneticOperator)
        {
            _selectedOperators.Add(geneticOperator);
        }

        public void DelOperator(OperadorViewModel geneticOperator)
        {
            _selectedOperators.Remove(geneticOperator);
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
