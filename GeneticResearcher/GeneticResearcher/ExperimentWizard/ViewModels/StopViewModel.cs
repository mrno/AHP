using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Persistencia;
using GeneticResearcher.Common;
using GeneticResearcher.ViewModels;
using GALibrary;
using GALibrary.Complementos;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class StopViewModel : ExperimentWizardPageViewModelBase
    {
        private ObservableCollection<StopConditionViewModel> _stopConditions;

        public StopViewModel(SesionExperimentacion session)
            : base(session)
        {
        }

        

        public ObservableCollection<StopConditionViewModel> StopConditions
        {
            get { return _stopConditions ?? (_stopConditions = GetAssemblyConvergenceMethods()); }
            set { _stopConditions = value; }
        }

        #region Methods
        
        private static ObservableCollection<StopConditionViewModel> GetAssemblyConvergenceMethods()
        {
            var operators = FacadeGAModule.ObtenerElementosAG(TipoElementoAG.CondicionParada);
            var lista = from op in operators
                        select new StopConditionViewModel(op, op, 0, "nada");

            return new ObservableCollection<StopConditionViewModel>(lista.OrderBy(x => x.DisplayName).ToList());
        }

        #endregion

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Parada"; }
        }

        public override string Description
        {
            get { return "Seleccione las condiciones de parada que desee y especifique el parámetro correspondiente."; }
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
