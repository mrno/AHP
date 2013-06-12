using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class PopulationViewModel : ExperimentWizardPageViewModelBase
    {
        public PopulationViewModel(SesionExperimentacion session)
            : base(session)
        {
        }

        private ReadOnlyCollection<OptionViewModel<string>> _convergenceMethods;

        public IEnumerable<OptionViewModel<string>> ConvergenceMethods
        {
            get { return _convergenceMethods ?? (_convergenceMethods = GetAssemblyConvergenceMethods()); }
        }

        private static ReadOnlyCollection<OptionViewModel<string>> GetAssemblyConvergenceMethods()
        {
            var operators = FacadeGAModule.ObtenerElementosAG(TipoElementoAG.ConvergenciaPoblacion);
            var lista = from op in operators
                        select new OptionViewModel<string>(op, op);

            return new ReadOnlyCollection<OptionViewModel<string>>(lista.OrderBy(x => x.DisplayName).ToList());
        }

        private ReadOnlyCollection<OptionViewModel<string>> _sizeOptions;

        public IEnumerable<OptionViewModel<string>> SizeOptions
        {
            get
            {
                if (_sizeOptions == null)
                {
                    var models = new List<OptionViewModel<string>>
                                     {
                                         new OptionViewModel<string>("50", "asd"),
                                         new OptionViewModel<string>("100", "asdf"),
                                         new OptionViewModel<string>("150", "asdf"),
                                         new OptionViewModel<string>("200", "asdf"),
                                         new OptionViewModel<string>("Custom", "asdf")
                                     };

                    _sizeOptions = new ReadOnlyCollection<OptionViewModel<string>>(models);

                    foreach (var option in _sizeOptions)
                    {
                        option.PropertyChanged += (sender, args) => OnPropertyChanged("IsCustom");
                    }
                }
                return _sizeOptions;
            }
        }

        public bool IsCustom 
        { 
            get { return _sizeOptions.Last().IsSelected; } 
        }

        public int CustomValue { get; set; }

        #region Overrides of ExperimentWizardPageViewModelBase

        public override string DisplayName
        {
            get { return "Población"; }
        }

        public override string Description
        {
            get { return "este es un texto"; }
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
