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
        private string _parameterDescription;

        public StopConditionViewModel(string name, string displayName, double parameter, string parameterDescription)
        {
            _name = name;
            _displayName = displayName;
            _isSelected = false;
            _parameter = parameter;
            _parameterDescription = parameterDescription;
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

        public string ParameterDescription
        {
            get { return _parameterDescription; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
