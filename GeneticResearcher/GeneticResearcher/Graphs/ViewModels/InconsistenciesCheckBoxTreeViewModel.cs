using GeneticResearcher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.Graphs.ViewModels
{
    public class InconsistenciesCheckBoxTreeViewModel : CheckBoxTreeViewModel
    {
        protected InconsistenciesCheckBoxTreeViewModel(string name) : base(name)
        {
        }

        public InconsistenciesCheckBoxTreeViewModel()
            : this("Niveles de Inconsistencia")
        {
            LoadChildren();
        }

        #region Overrides of CheckBoxTreeViewModel

        public override void LoadChildren()
        {
            var root = new InconsistenciesCheckBoxTreeViewModel(Name)
            {
                IsInitiallySelected = true,
                Children = new List<CheckBoxTreeViewModel>()
                                   {
                                       new InconsistenciesCheckBoxTreeViewModel("Consistente"),
                                       new InconsistenciesCheckBoxTreeViewModel("I. Bajo"),
                                       new InconsistenciesCheckBoxTreeViewModel("I. Media"),
                                       new InconsistenciesCheckBoxTreeViewModel("I. Alto")
                                   }
            };
            root.Initialize();
            Children = new List<CheckBoxTreeViewModel> { root };
        }

        #endregion
    }
}
