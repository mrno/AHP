using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeneticResearcher.Command;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class ExperimentWizardUnitMatrixFitnessFuncionComparisonViewModel : ExperimentWizardViewModel
    {
        #region Constructor

        public ExperimentWizardUnitMatrixFitnessFuncionComparisonViewModel()
        {
            CreatePages();
            CurrentPage = Pages[0];
        }

        #endregion // Constructor
        
        #region Private Helpers

        void CreatePages()
        {
            var pages = new List<ExperimentWizardPageViewModelBase>
                            {
                                new StartViewModel(Sesion),
                                new GeneticSelectionViewModel(Sesion),
                                new GeneticCrossoverViewModel(Sesion),
                                new GeneticMutationViewModel(Sesion),
                                new PopulationViewModel(Sesion),
                                new StopViewModel(Sesion),
                                new SummaryViewModel(Sesion)
                            };
            _pages = new ReadOnlyCollection<ExperimentWizardPageViewModelBase>(pages);
        }

        #endregion

    }
}
