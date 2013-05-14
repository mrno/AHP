using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.ExperimentWizard.ViewModels
{
    public class StopViewModel : ExperimentWizardPageViewModelBase
    {
        private ObservableCollection<StopConditionViewModel> _stopConditions;

        public StopViewModel(SesionExperimentacion sesion) : base(sesion)
        {
        }

        

        public ObservableCollection<StopConditionViewModel> StopConditions
        {
            get { return _stopConditions ?? (_stopConditions = LoadConditions()); }
            set { _stopConditions = value; }
        }

        #region Methods

        private ObservableCollection<StopConditionViewModel> LoadConditions()
        {
            var conditions = new List<StopConditionViewModel>
                                 {
                                     new StopConditionViewModel("asd", "alto nombre re largo de prueba", 0, "alto parámetro"),
                                     new StopConditionViewModel("otra", "otro nombre de condicion de prueba", 3, "otro parámetro")
                                 };
            return new ObservableCollection<StopConditionViewModel>(conditions);
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

        #endregion
    }
}
