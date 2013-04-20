using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.CondicionParada
{
    public class ParadaConvergencia: ICondicionParada
    {
        private double _convergencia;

        public ParadaConvergencia(string convergencia)
        {
            _convergencia = double.Parse(convergencia, CultureInfo.InvariantCulture);
        }

        public bool Parar(Poblacion poblacion)
        {
            return poblacion.Convergencia >= _convergencia;
        }

    }
}
