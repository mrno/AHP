using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Persistencia;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public abstract class ExperimentWizardPageViewModelBase : INotifyPropertyChanged
    {
        #region Fields

        readonly SesionExperimentacion _sesion;
        bool _isCurrentPage;

        #endregion // Fields

        #region Constructor

        protected ExperimentWizardPageViewModelBase(SesionExperimentacion sesion)
        {
            _sesion = sesion;
        }

        #endregion // Constructor

        #region Properties

        public SesionExperimentacion Sesion
        {
            get { return _sesion; }
        } 

        public abstract string DisplayName { get; }

        public bool IsCurrentPage
        {
            get { return _isCurrentPage; }
            set 
            {
                if (value == _isCurrentPage)
                    return;

                _isCurrentPage = value;
                this.OnPropertyChanged("IsCurrentPage");
            }
        }

        public abstract string Description { get; }

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Returns true if the user has filled in this page properly
        /// and the wizard should allow the user to progress to the 
        /// next page in the workflow.
        /// </summary>
        internal abstract bool IsValid();

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
