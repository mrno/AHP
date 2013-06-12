using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class ValorarProyectosViewModel
    {
        public TrackILViewModel TrackILViewModel { get; set; }

        public ValorarProyectosViewModel()
        {
            TrackILViewModel = new TrackILViewModel();
        }
    }
}
