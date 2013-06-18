using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Complementos;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.CondicionParada
{
    [ElementoAG(TipoElementoAG.CondicionParada, "ParadaAptitudMejorIndividuo")]
    public class ParadaAptitudMejorIndividuo : ICondicionParada
    {
        private double _aptitud;

        public ParadaAptitudMejorIndividuo(string aptitudNecesaria)
        {
            _aptitud = double.Parse(aptitudNecesaria);
        }

        public bool Parar(Poblacion poblacion)
        {
            return poblacion.MejorIndividuo.Aptitud >= _aptitud;
        }
    }
}
