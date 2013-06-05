using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.Graphs.ViewModels
{
    public class DisplayDataViewModel : INotifyPropertyChanged
    {
        #region Fields
        #endregion

        #region Constructors

        public DisplayDataViewModel()
        {
            Orders = new CheckBoxTreeViewModel {}
        }

        #endregion

        #region Properties

        public CheckBoxTreeViewModel Orders { get; private set; }

        public CheckBoxTreeViewModel Inconsistencies { get; private set; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
