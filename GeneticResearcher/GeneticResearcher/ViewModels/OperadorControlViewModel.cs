using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.ViewModels
{
    public class OperadorControlViewModel
    {
        public OperadorControlViewModel()
        {
            Porcentaje = 0;
        }

        public int Porcentaje { get; set; }

        public IEnumerable<string> OperadoresDisponibles
        {
            get { return new List<string>() {"Elitista", "Uniforme", "MutadorSimple", "CruzadorSimple", "asd", "abc", "aaa"}; }
        }

        public IEnumerable<string> OperadoresSeleccionados
        {
            get { return new List<string>() {"Ruleta"}; }
        }
    }
}
