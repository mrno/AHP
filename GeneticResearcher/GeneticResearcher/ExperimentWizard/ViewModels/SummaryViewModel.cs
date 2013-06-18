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
    public class SummaryViewModel : ExperimentWizardPageViewModelBase
    {
        public SummaryViewModel(SesionExperimentacion session)
            : base(session)
        {
            Experiment = new ExperimentViewModel(session);
        }

        #region Overrides of ExperimentWizardPageViewModelBase

        public ExperimentViewModel Experiment { get; private set; }

        public override string DisplayName
        {
            get { return "Summary"; }
        }

        internal override bool IsValid()
        {
            return true;
        }

        internal override void SaveChangesInExperimentSession()
        {
        }

        public override string Description
        {
            get { return "Total debe ser 100 y debe elegir algún modelo"; }
        }

        #endregion
    }
}
