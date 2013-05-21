using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto.UI.Clases
{
    public class ResultadoViewModel
    {
        public string Alternativa { get; set; }
        public double ValorPorcentaje { get; set; }

        public string Porcentaje 
        {
            get
            {
                return string.Format("{0:0.00%}", ValorPorcentaje);
            }
        }
    }
}
