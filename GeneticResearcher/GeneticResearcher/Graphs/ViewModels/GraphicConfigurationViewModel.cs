using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.Graphs.ViewModels
{
    public class GraphicConfigurationViewModel
    {
        #region Constructors

        public GraphicConfigurationViewModel()
        {
            DisplayData = new DisplayDataViewModel();
            OrderData = new OrderDataViewModel();
            GroupData = new GroupDataViewModel();
        }

        #endregion

        #region Properties

        public DisplayDataViewModel DisplayData { get; private set; }
        public OrderDataViewModel OrderData { get; private set; }
        public GroupDataViewModel GroupData { get; private set; }

        #endregion
    }
}
