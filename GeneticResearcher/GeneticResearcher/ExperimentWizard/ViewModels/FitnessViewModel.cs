using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class FitnessViewModel : ExperimentWizardPageViewModelBase
    {
        public FitnessViewModel(SesionExperimentacion sesion) : base(sesion)
        {
        }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Aptitud"; }
        }

        public override string Description
        {
            get { return "nada"; }
        }

        internal override bool IsValid()
        {
            return true;
        }

        #endregion
    }
}
