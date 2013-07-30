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

        public ParadaConsistencia(string consistencia)
        {
            _inconsistencia = double.Parse(consistencia);
        }

        public bool Parar(Poblacion poblacion)
        {
            return poblacion.MejorIndividuo.Inconsistencia <= _inconsistencia;
        }
    }
}
