using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GALibrary.Persistencia;
using GeneticResearcher.Command;
using GeneticResearcher.Common;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class ExperimentWizardViewModel : INotifyPropertyChanged
    {
        #region Fields

        RelayCommand _cancelCommand;
        SesionExperimentacion _session;
        ExperimentWizardPageViewModelBase _currentPage;
        RelayCommand _moveNextCommand;
        RelayCommand _movePreviousCommand;
        protected ReadOnlyCollection<ExperimentWizardPageViewModelBase> _pages;

        #endregion // Fields

        #region Constructor

        public ExperimentWizardViewModel()
        {
            _session = new SesionExperimentacion();
            CurrentPage = Pages[0];
        }

        #endregion // Constructor

        #region Commands

        #region CancelCommand

        /// <summary>
        /// Returns the command which, when executed, cancels the wizard 
        /// and causes the Wizard to be removed from the user interface.
        /// </summary>
        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand(CancelOrder)); }
        }

        void CancelOrder()
        {
            _session = null;
            OnRequestClose();
        }

        #endregion // CancelCommand

        #region MovePreviousCommand

        /// <summary>
        /// Returns the command which, when executed, causes the CurrentPage 
        /// property to reference the previous page in the workflow.
        /// </summary>
        public ICommand MovePreviousCommand
        {
            get
            {
                return _movePreviousCommand ?? (_movePreviousCommand = new RelayCommand(
                                                                           MoveToPreviousPage,
                                                                           () => CanMoveToPreviousPage));
            }
        }

        bool CanMoveToPreviousPage
        {
            get { return 0 < CurrentPageIndex; }
        }

        void MoveToPreviousPage()
        {
            if (CanMoveToPreviousPage)
            {
                CurrentPage.SaveChangesInExperimentSession();
                CurrentPage = Pages[CurrentPageIndex - 1];
            }
        }

        #endregion // MovePreviousCommand

        #region MoveNextCommand

        /// <summary>
        /// Returns the command which, when executed, causes the CurrentPage 
        /// property to reference the next page in the workflow.  If the user
        /// is viewing the last page in the workflow, this causes the Wizard
        /// to finish and be removed from the user interface.
        /// </summary>
        public ICommand MoveNextCommand
        {
            get
            {
                return _moveNextCommand ?? (_moveNextCommand = new RelayCommand(
                                                                   MoveToNextPage,
                                                                   () => CanMoveToNextPage));
            }
        }

        bool CanMoveToNextPage
        {
            get { return CurrentPage != null && CurrentPage.IsValid(); }
        }

        void MoveToNextPage()
        {
            if (CanMoveToNextPage)
            {
                CurrentPage.SaveChangesInExperimentSession();
                if (CurrentPageIndex < Pages.Count - 1)
                    CurrentPage = Pages[CurrentPageIndex + 1];
                else
                    OnRequestClose();
            }
        }

        #endregion // MoveNextCommand

        #endregion // Commands

        #region Properties

        /// <summary>
        /// Returns the cup of coffee ordered by the customer.
        /// If this returns null, the user cancelled the order.
        /// </summary>
        public SesionExperimentacion Session
        {
            get { return _session; }
        }

        /// <summary>
        /// Returns the page ViewModel that the user is currently viewing.
        /// </summary>
        public ExperimentWizardPageViewModelBase CurrentPage
        {
            get { return _currentPage; }
            protected set
            {
                if (value == _currentPage)
                    return;

                if (_currentPage != null)
                    _currentPage.IsCurrentPage = false;

                _currentPage = value;

                if (_currentPage != null)
                    _currentPage.IsCurrentPage = true;

                OnPropertyChanged("CurrentPage");
                OnPropertyChanged("IsOnLastPage");
            }
        }

        /// <summary>
        /// Returns true if the user is currently viewing the last page 
        /// in the workflow.  This property is used by CoffeeWizardView
        /// to switch the Next button's text to "Finish" when the user
        /// has reached the final page.
        /// </summary>
        public bool IsOnLastPage
        {
            get { return CurrentPageIndex == Pages.Count - 1; }
        }

        /// <summary>
        /// Returns a read-only collection of all page ViewModels.
        /// </summary>
        public ReadOnlyCollection<ExperimentWizardPageViewModelBase> Pages
        {
            get
            {
                if (_pages == null)
                    CreatePages();

                return _pages;
            }
        }

        public string RequirementToNext
        {
            get { return CurrentPage.Description; }
        }

        #endregion // Properties

        #region Events

        /// <summary>
        /// Raised when the wizard should be removed from the UI.
        /// </summary>
        public event EventHandler RequestClose;

        #endregion // Events

        #region Private Helpers

        void CreatePages()
        {
            var pages = new List<ExperimentWizardPageViewModelBase>
                            {
                                new StartViewModel(Session),
                                new GeneticSelectionViewModel(Session),
                                new GeneticCrossoverViewModel(Session),
                                new GeneticMutationViewModel(Session),
                                new PopulationViewModel(Session),
                                new IndividualViewModel(Session),
                                new StopViewModel(Session),
                                new GeneticTestSetViewModel(Session),
                                new SummaryViewModel(Session)
                            };
            _pages = new ReadOnlyCollection<ExperimentWizardPageViewModelBase>(pages);
        }

        int CurrentPageIndex
        {
            get
            {

                if (CurrentPage == null)
                {
                    Debug.Fail("Why is the current page null?");
                    return -1;
                }

                return Pages.IndexOf(CurrentPage);
            }
        }

        void OnRequestClose()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion // Private Helpers

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members

    }
}
