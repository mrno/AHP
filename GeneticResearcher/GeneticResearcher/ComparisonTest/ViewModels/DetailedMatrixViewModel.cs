using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.ComparisonTest.ViewModels
{
    public class DetailedMatrixViewModel: INotifyPropertyChanged
    {
        #region Fields

        #endregion

        #region Constructors

        public DetailedMatrixViewModel(int dimension)
        {
            Matrix = new MatrixViewModel(dimension);
        }

        #endregion

        #region Properties

        public MatrixViewModel Matrix { get; private set; }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

