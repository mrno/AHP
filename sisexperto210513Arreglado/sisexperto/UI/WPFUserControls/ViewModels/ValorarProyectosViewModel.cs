using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class ValorarProyectosViewModel
    {
        public ValoracionAHPViewModel ValoracionAHP { get; set; }
        public ValoracionILViewModel ValoracionIL { get; set; }

        public bool TieneAHP
        {
            get { return ValoracionAHP != null; }
        }

        public bool TieneIL
        {
            get { return ValoracionIL != null; }
        }

        public bool MostrarAHP { get; set; }

        public bool MostrarIL
        {
            get { return !MostrarAHP; }
        }

        public ValorarProyectosViewModel()
        {
            
        }
    }
}
