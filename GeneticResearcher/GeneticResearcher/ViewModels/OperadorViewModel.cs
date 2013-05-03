using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ViewModels
{
    public class OperadorViewModel : INotifyPropertyChanged
    {
        #region Fields
        
        private readonly string _displayName;
        private readonly string _name;

        #endregion // Fields

        #region Constructor

        public OperadorViewModel(string displayName)
        {
            _displayName = displayName;
            _name = displayName;
        }

        public OperadorViewModel(string displayName, string name)
        {
            _displayName = displayName;
            _name = name;
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Returns the user-friendly name of this option.
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
        }

        /// <summary>
        /// Returns the name of the operator.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        #endregion // Properties

        #region Methods

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
