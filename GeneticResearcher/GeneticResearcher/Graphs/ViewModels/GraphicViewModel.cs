using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.Graphs.ViewModels
{
    public class GraphicViewModel
    {
        #region Constructors

        public GraphicViewModel()
        {
            GraphicConfiguration = new GraphicConfigurationViewModel();
        }

        #endregion

        #region Properties

        public GraphicConfigurationViewModel GraphicConfiguration { get; private set; }

        #endregion
    }
}
