using System;
using System.ComponentModel;

namespace GeneticResearcher.ViewModels
{
    public class OptionViewModel<TValue> :
        INotifyPropertyChanged,
        IComparable<OptionViewModel<TValue>>
    {
        #region Fields

        private const int UNSET_SORT_VALUE = Int32.MinValue;

        private readonly string _displayName;
        private readonly int _sortValue;
        private readonly TValue _value;
        private bool _isSelected;

        #endregion // Fields

        #region Constructor

        public OptionViewModel(string displayName, TValue value)
            : this(displayName, value, UNSET_SORT_VALUE)
        {
        }

        public OptionViewModel(string displayName, TValue value, int sortValue)
        {
            _displayName = displayName;
            _value = value;
            _sortValue = sortValue;
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
        /// Gets/sets whether this option is in the selected state.
        /// When this property is set to a new value, this object's
        /// PropertyChanged event is raised.
        /// </summary>
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

        /// <summary>
        /// Returns the value used to sort this option.
        /// The default sort value is Int32.MinValue.
        /// </summary>
        public int SortValue
        {
            get { return _sortValue; }
        }

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Returns the underlying value of this option.
        /// Note: this is a method, instead of a property,
        /// so that the UI cannot bind to it.
        /// </summary>
        internal TValue GetValue()
        {
            return _value;
        }

        #endregion // Methods

        #region IComparable<OptionViewModel<TValue>> Members

        public int CompareTo(OptionViewModel<TValue> other)
        {
            if (other == null)
                return -1;

            if (SortValue == UNSET_SORT_VALUE && other.SortValue == UNSET_SORT_VALUE)
            {
                return DisplayName.CompareTo(other.DisplayName);
            }
            if (SortValue != UNSET_SORT_VALUE && other.SortValue != UNSET_SORT_VALUE)
            {
                return SortValue.CompareTo(other.SortValue);
            }
            if (SortValue != UNSET_SORT_VALUE && other.SortValue == UNSET_SORT_VALUE)
            {
                return -1;
            }
            
            {
                return +1;
            }
        }

        #endregion

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