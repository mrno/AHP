using System.Collections.Generic;
using System.ComponentModel;
using GeneticResearcher.Graphs.ViewModels;

namespace GeneticResearcher.ViewModels
{
    public abstract class CheckBoxTreeViewModel : ICheckBoxTreeViewModel
    {
        #region Data

        private bool? _isChecked = false;
        private CheckBoxTreeViewModel _parent;

        #endregion // Data

        #region Constructors & Initialization
        
        protected CheckBoxTreeViewModel(string name)
        {
            Name = name;
            Children = new List<CheckBoxTreeViewModel>();
        }

        public abstract void LoadChildren();
    
        protected void Initialize()
        {
            foreach (CheckBoxTreeViewModel child in Children)
            {
                child._parent = this;
                child.Initialize();
            }
        }

        #endregion

        #region Properties

        public List<CheckBoxTreeViewModel> Children { get; protected set; }

        public bool ChildrenLoaded { get; protected set; }

        public bool IsInitiallySelected { get; protected set; }

        public string Name { get; protected set; }
        
        #region IsChecked

        /// <summary>
        /// Gets/sets the state of the associated UI toggle (ex. CheckBox).
        /// The return value is calculated based on the check state of all
        /// child FooViewModels.  Setting this property to true or false
        /// will set all children to the same check state, and setting it 
        /// to any value will cause the parent to verify its check state.
        /// </summary>
        public bool? IsChecked
        {
            get { return _isChecked; }
            set { SetIsChecked(value, true, true); }
        }

        private void SetIsChecked(bool? value, bool updateChildren, bool updateParent)
        {
            if (value == _isChecked)
                return;

            _isChecked = value;

            if (updateChildren && _isChecked.HasValue)
                Children.ForEach(c => c.SetIsChecked(_isChecked, true, false));

            if (updateParent && _parent != null)
                _parent.VerifyCheckState();

            OnPropertyChanged("IsChecked");
        }

        private void VerifyCheckState()
        {
            bool? state = null;
            for (int i = 0; i < Children.Count; ++i)
            {
                bool? current = Children[i].IsChecked;
                if (i == 0)
                {
                    state = current;
                }
                else if (state != current)
                {
                    state = null;
                    break;
                }
            }
            SetIsChecked(state, false, true);
        }

        #endregion // IsChecked

        #endregion // Properties

        #region IConjuntoMatrizViewModel Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
