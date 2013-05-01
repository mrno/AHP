using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class SummaryViewModel : ExperimentWizardPageViewModelBase
    {
        public SummaryViewModel(SesionExperimentacion sesion) : base(sesion)
        {
        }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Summary"; }
        }

        internal override bool IsValid()
        {
            return true;
        }

        #endregion
    }
}
