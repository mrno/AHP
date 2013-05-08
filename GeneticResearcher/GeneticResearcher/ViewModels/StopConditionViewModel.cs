using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ViewModels
{
    public class StopConditionViewModel : INotifyPropertyChanged
    {
        private string _displayName;
        private string _name;
        private bool _isSelected;
        private double _parameter;

        public StopConditionViewModel(string name, string displayName)
        {
            _name = name;
            _displayName = displayName;
            _isSelected = false;
        }

        public double Parameter
        {
            get { return _parameter; }
            set
            {
                if (value == _parameter)
                    return;

                _parameter = value;
                OnPropertyChanged("Parameter");
            }
        }

        public string Name
        {
            get { return _name; }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected)
                    return;

                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
