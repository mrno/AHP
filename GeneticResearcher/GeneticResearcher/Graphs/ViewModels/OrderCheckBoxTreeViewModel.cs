using GeneticResearcher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.Graphs.ViewModels
{
    public class OrderCheckBoxTreeViewModel : CheckBoxTreeViewModel
    {
        protected OrderCheckBoxTreeViewModel(string name) : base(name)
        {
        }

        public OrderCheckBoxTreeViewModel()
            : this("Ordenes")
        {
            LoadChildren();
        }

        #region Overrides of CheckBoxTreeViewModel

        public override void LoadChildren()
        {
            var root = new OrderCheckBoxTreeViewModel(Name)
            {
                IsInitiallySelected = true,
                Children = new List<CheckBoxTreeViewModel>()
                                   {
                                       new OrderCheckBoxTreeViewModel("4"),
                                       new OrderCheckBoxTreeViewModel("5"),
                                       new OrderCheckBoxTreeViewModel("6"),
                                       new OrderCheckBoxTreeViewModel("7"),
                                       new OrderCheckBoxTreeViewModel("8"),
                                       new OrderCheckBoxTreeViewModel("9"),
                                   }
            };
            root.Initialize();
            Children = new List<CheckBoxTreeViewModel> { root };
        }

        #endregion
    }
}
