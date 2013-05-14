using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            get
            {
                if (_evolutiveModels == null)
                {
                    var models = new List<OptionViewModel<string>>
                                     {
                                         new OptionViewModel<string>("ModeloEvolutivoEstandar", "asd"),
                                         new OptionViewModel<string>("ModeloEvolutivoAlternativo", "asdf")
                                     };

                    _evolutiveModels = new ReadOnlyCollection<OptionViewModel<string>>(models);
                }
                return _evolutiveModels;
            }
        }

        public StartViewModel(SesionExperimentacion sesion) : base(sesion)
        {
        }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Comienzo"; }
        }

        internal override bool IsValid()
        {
            return true;
            return Is100Percent && EvolutiveModels.Any(x => x.IsSelected);
        }

        public override string Description 
        {
            get { return "Total debe ser 100 y debe elegir algún modelo"; }
        }

        #endregion
    }
}
