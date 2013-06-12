using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class ValoracionILViewModel
    {
        public TrackILViewModel TrackILViewModel { get; set; }

        public ValoracionILViewModel()
        {
            TrackILViewModel = new TrackILViewModel();
        }
    }
}
