using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class StopViewModel : ExperimentWizardPageViewModelBase
    {


        public StopViewModel(SesionExperimentacion sesion) : base(sesion)
        {
        }


        public IEnumerable<StopConditionViewModel> StopConditions { get; set; }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Parada"; }
        }

        public override string Description
        {
            get { return "nada 2"; }
        }

        internal override bool IsValid()
        {
            return true;
        }

        #endregion
    }
}
