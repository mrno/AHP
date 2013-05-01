using System.Collections.Generic;
using System.ComponentModel;

namespace GeneticResearcher.ViewModels
{
    public class ConjuntoMatrizViewModel : IConjuntoMatrizViewModel
    {
        #region Data

        private bool? _isChecked = false;
        private ConjuntoMatrizViewModel _parent;

        #endregion // Data

        #region CreateFoos

        public ConjuntoMatrizViewModel()
        {
            Name = "Conjuntos";
            Children = CreateFoos();
        }

        private ConjuntoMatrizViewModel(string name)
        {
            Name = name;
            Children = new List<ConjuntoMatrizViewModel>();
        }

        public static List<ConjuntoMatrizViewModel> CreateFoos()
        {
            var root = new ConjuntoMatrizViewModel("Weapons")
                           {
                               IsInitiallySelected = true,
                               Children =
                                   {
                                       new ConjuntoMatrizViewModel("Blades")
                                           {
                                               Children =
                                                   {
                                                       new ConjuntoMatrizViewModel("Dagger"),
                                                       new ConjuntoMatrizViewModel("Machete"),
                                                       new ConjuntoMatrizViewModel("Sword"),
                                                   }
                                           }
                                   }
                           };

            root.Initialize();
            return new List<ConjuntoMatrizViewModel> {root};
        }

        private void Initialize()
        {
            foreach (ConjuntoMatrizViewModel child in Children)
            {
                child._parent = this;
                child.Initialize();
            }
        }

        #endregion // CreateFoos

        #region Properties

        public List<ConjuntoMatrizViewModel> Children { get; private set; }

        public bool IsInitiallySelected { get; private set; }

        public string Name { get; private set; }
        
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

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}