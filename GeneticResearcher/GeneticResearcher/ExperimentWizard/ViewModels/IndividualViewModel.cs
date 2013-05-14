using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class IndividualViewModel : ExperimentWizardPageViewModelBase
    {
        public IndividualViewModel(SesionExperimentacion sesion) : base(sesion)
        {
        }

        private ReadOnlyCollection<OptionViewModel<string>> _fitnessFuncions;

        public IEnumerable<OptionViewModel<string>> FitnessFunctions
        {
            get
            {
                if (_fitnessFuncions == null)
                {
                    var models = new List<OptionViewModel<string>>
                                     {
                                         new OptionViewModel<string>("Función Lineal", "asd"),
                                         new OptionViewModel<string>("Función Exponencial", "asdf")
                                     };

                    _fitnessFuncions = new ReadOnlyCollection<OptionViewModel<string>>(models);
                }
                return _fitnessFuncions;
            }
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

        #endregion
    }
}
