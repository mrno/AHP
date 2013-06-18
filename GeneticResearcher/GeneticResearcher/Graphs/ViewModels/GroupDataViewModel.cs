using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.Graphs.ViewModels
{
    public class GroupDataViewModel : INotifyPropertyChanged
    {
        private ReadOnlyCollection<OptionViewModel<string>> _orderOptions;

        public  GroupDataViewModel()
        {
            var models = new List<OptionViewModel<string>>
                                     {
                                         new OptionViewModel<string>("No", "No"),
                                         new OptionViewModel<string>("1º", "1"),
                                         new OptionViewModel<string>("2º", "2")
                                     };

            _orderOptions = new ReadOnlyCollection<OptionViewModel<string>>(models);

            FirstOption = OrderOptions.First();
            SecondOption = OrderOptions.First();
        }

        private OptionViewModel<string> _firstOption;

        public OptionViewModel<string> FirstOption
        {
            get { return _firstOption; }
            set
            {
                if (value == _secondOption && value != _orderOptions.First())
                {
                    _secondOption = _orderOptions.First();
                    OnPropertyChanged("SecondOption");
                }
                _firstOption = value;

                OnPropertyChanged("OrderOptions");
            }
        }

        private OptionViewModel<string> _secondOption;
        public OptionViewModel<string> SecondOption
        {
            get { return _secondOption; }
            set
            {
                if (value == _firstOption && value != _orderOptions.First())
                {
                    _firstOption = _orderOptions.First();
                    OnPropertyChanged("FirstOption");
                }
                _secondOption = value;

                OnPropertyChanged("OrderOptions");
            }
        }

        public IEnumerable<OptionViewModel<string>> OrderOptions
        {
            get
            {
                if (_firstOption == _orderOptions.First() && _secondOption == _orderOptions.First())
                    return _orderOptions.Take(2);
                return _orderOptions;
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
