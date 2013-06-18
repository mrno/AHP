using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Persistencia;
using GeneticResearcher.Common;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class GeneticMutationViewModel : ExperimentWizardPageViewModelBase
    {
        public OperatorControlViewModel Operator { get; private set; }

        public GeneticMutationViewModel(SesionExperimentacion session)
            : base(session)
        {
            Operator = new OperatorControlViewModel();
        }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Mutacion"; }
        }

        internal override bool IsValid()
        {
            return true;
        }

        internal override void SaveChangesInExperimentSession()
        {
            Session.Mutacion = Operator.SelectedOperatorsNames;
        }

        public override string Description
        {
            get { return "Total debe ser 100 y debe elegir algún modelo"; }
        }

        #endregion
    }
}
