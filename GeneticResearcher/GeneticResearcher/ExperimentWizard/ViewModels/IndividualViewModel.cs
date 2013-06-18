using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary;
using GALibrary.Complementos;
using GALibrary.Persistencia;
using GeneticResearcher.Common;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class IndividualViewModel : ExperimentWizardPageViewModelBase
    {
        public IndividualViewModel(SesionExperimentacion session)
            : base(session)
        {
        }

        private ReadOnlyCollection<OptionViewModel<string>> _fitnessFuncions;

        public IEnumerable<OptionViewModel<string>> FitnessFunctions
        {
            get { return _fitnessFuncions ?? (_fitnessFuncions = GetAssemblyFitnessFunctions()); }
        }

        private static ReadOnlyCollection<OptionViewModel<string>> GetAssemblyFitnessFunctions()
        {
            var operators = FacadeGAModule.ObtenerElementosAG(TipoElementoAG.FuncionAptitud);
            var lista = from op in operators
                        select new OptionViewModel<string>(op, op);

            return new ReadOnlyCollection<OptionViewModel<string>>(lista.OrderBy(x => x.DisplayName).ToList());
        }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Individuos"; }
        }

        public override string Description
        {
            get { return "nada"; }
        }

        internal override bool IsValid()
        {
            return true;
        }

        internal override void SaveChangesInExperimentSession()
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
