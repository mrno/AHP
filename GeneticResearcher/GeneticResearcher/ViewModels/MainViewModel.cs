using System.ComponentModel;

namespace GeneticResearcher.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        #endregion // Fields

        #region Constructor

        public MainViewModel()
        {
            //TODO: buscar en BD
            ExperimentResults = new ExperimentResultsViewModel();
        }

        #endregion // Constructor

        #region Properties

        public ExperimentResultsViewModel ExperimentResults { get; set; }
        
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
