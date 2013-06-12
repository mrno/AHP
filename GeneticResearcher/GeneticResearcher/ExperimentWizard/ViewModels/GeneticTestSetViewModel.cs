using GALibrary.Persistencia;
using GeneticResearcher.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class GeneticTestSetViewModel : ExperimentWizardPageViewModelBase
    {
        private ConjuntoMatrizViewModel _conjuntoMatriz;

        public GeneticTestSetViewModel(SesionExperimentacion sesion) : base(sesion)
        {
        }

        public ConjuntoMatrizViewModel ConjuntoMatriz
        {
            get { return _conjuntoMatriz ?? (_conjuntoMatriz = new ConjuntoMatrizViewModel()); }
        }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Conjuntos"; }
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
