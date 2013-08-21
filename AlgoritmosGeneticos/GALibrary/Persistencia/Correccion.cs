using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.Persistencia
{
    public abstract class Correccion
    {
        public ParametrosEjecucion ParametrosEjecucion { get; set; }

        public ObjetoMatriz MatrizOriginal { get; set; }
        public ObjetoMatriz MatrizCorregida { get; set; }

        public ValoresSalidaEjecucion ValoresSalidaEjecucion { get; set; }
    }
}
