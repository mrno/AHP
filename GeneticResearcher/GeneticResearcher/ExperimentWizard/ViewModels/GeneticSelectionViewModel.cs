using GALibrary.Persistencia;
using GeneticResearcher.Common;
using GeneticResearcher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class GeneticSelectionViewModel : ExperimentWizardPageViewModelBase
    {
        public OperatorControlViewModel Operator { get; private set; }

        public GeneticSelectionViewModel(SesionExperimentacion session)
            : base(session)
        {
            Operator = new OperatorControlViewModel();
        }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Seleccion"; }
        }

        internal override bool IsValid()
        {
            return true;
        }

        internal override void SaveChangesInExperimentSession()
        {
            Session.Seleccion = Operator.SelectedOperatorsNames;
        }

        public override string Description
        {
            get { return "Total debe ser 100 y debe elegir algún modelo"; }
        }

        #endregion
    }
}
