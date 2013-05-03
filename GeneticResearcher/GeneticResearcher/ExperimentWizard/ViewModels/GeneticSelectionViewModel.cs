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
        public OperadorControlViewModel Operador { get; private set; }

        public GeneticSelectionViewModel(SesionExperimentacion sesion) : base(sesion)
        {
            Operador = new OperadorControlViewModel();
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

        public override string Description
        {
            get { return "Total debe ser 100 y debe elegir algún modelo"; }
        }

        #endregion
    }
}
