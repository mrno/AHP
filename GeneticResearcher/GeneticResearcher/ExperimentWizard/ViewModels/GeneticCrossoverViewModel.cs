using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Persistencia;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class GeneticCrossoverViewModel : ExperimentWizardPageViewModelBase
    {
        public OperadorControlViewModel Operador { get; private set; }

        public GeneticCrossoverViewModel(SesionExperimentacion sesion)
            : base(sesion)
        {
            Operador = new OperadorControlViewModel();
        }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Cruza"; }
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
