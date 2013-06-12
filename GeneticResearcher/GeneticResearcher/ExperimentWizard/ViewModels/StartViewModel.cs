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
    public class StartViewModel : ExperimentWizardPageViewModelBase
    {
        private int _selection;
        private int _crossover;
        private int _mutation;

        public int SelectionPercentage
        {
            get { return _selection; } 
            set
            {
                _selection = value;
                OnPropertyChanged("SelectionPercentage");
                OnPropertyChanged("TotalPercentage");
                OnPropertyChanged("Is100Percent");
            }
        }
        public int CrossoverPercentage
        {
            get { return _crossover; }
            set
            {
                _crossover = value;
                OnPropertyChanged("CrossoverPercentage");
                OnPropertyChanged("TotalPercentage");
                OnPropertyChanged("Is100Percent");
            }
        }
        public int MutationPercentage
        {
            get { return _mutation; }
            set
            {
                _mutation = value;
                OnPropertyChanged("MutationPercentage");
                OnPropertyChanged("TotalPercentage");
                OnPropertyChanged("Is100Percent");
            }
        }

        public bool Is100Percent
        {
            get
            {
                return (SelectionPercentage + CrossoverPercentage + MutationPercentage) == 100;
            }
        }

        public int TotalPercentage
        {
            get { return _selection + _crossover + _mutation;}
        }

        private ReadOnlyCollection<OptionViewModel<string>> _evolutiveModels; 

        public IEnumerable<OptionViewModel<string>> EvolutiveModels
        {
            get { return _evolutiveModels ?? (_evolutiveModels = GetAssemblyEvolutiveModels()); }
        }

        private static ReadOnlyCollection<OptionViewModel<string>> GetAssemblyEvolutiveModels()
        {
            var operators = FacadeGAModule.ObtenerElementosAG(TipoElementoAG.ModeloEvolutivo);
            var lista = from op in operators
                        select new OptionViewModel<string>(op, op);

            return new ReadOnlyCollection<OptionViewModel<string>>(lista.OrderBy(x => x.DisplayName).ToList());
        }

        public StartViewModel(SesionExperimentacion session)
            : base(session)
        {
        }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Comienzo"; }
        }

        internal override bool IsValid()
        {
            return Is100Percent && EvolutiveModels.Any(x => x.IsSelected);
        }

        internal override void SaveChangesInExperimentSession()
        {
            //Session.PorcentajeSeleccion = SelectionPercentage;
            //Session.PorcentajeCruza = CrossoverPercentage;
            //Session.PorcentajeMaximoMutacion = MutationPercentage;

            //var model = EvolutiveModels.FirstOrDefault(x => x.IsSelected);
            //Session.ModeloEvolutivo = model != null ? model.GetValue() : "";
        }

        public override string Description 
        {
            get { return "Total debe ser 100 y debe elegir algún modelo"; }
        }

        #endregion
    }
}
