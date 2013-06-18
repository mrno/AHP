using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Complementos;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.CondicionParada
{
    [ElementoAG(TipoElementoAG.CondicionParada, "ParadaConsistencia")]
    public class ParadaConsistencia: ICondicionParada
    {
        private double _inconsistencia;

        public ParadaConsistencia(string convergencia)
        {
            _inconsistencia = double.Parse(convergencia, CultureInfo.InvariantCulture);
        }

        public bool Parar(Poblacion poblacion)
        {
            return poblacion.Individuos.Any(x => x.Inconsistencia <= _inconsistencia);
        }

    }
}
