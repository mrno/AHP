using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.Persistencia
{
    public abstract class ValoresSalidaEjecucion
    {
        public virtual int Id { get; set; }

        public virtual bool CoincidePrimerElementoRanking { get; set; }

        public virtual DateTime Inicio { get; set; }
        public virtual DateTime Fin { get; set; }
        public virtual TimeSpan Duracion { get; set; }

        public virtual double Error { get; set; }
        public virtual double ErrorRelativo { get; set; }
    }

    public class ValoresSalidaEjecucionAG : ValoresSalidaEjecucion
    {
        public virtual double Cambios { get; set; }

        public virtual double AptitudPromedioInicialPoblacion { get; set; }
        public virtual double AptitudPromedioFinalPoblacion { get; set; }

        public virtual double AptitudInicialMejorIndividuo { get; set; }
        public virtual double AptitudFinalMejorIndividuo { get; set; }

        public virtual int IteracionesRealizadas { get; set; }
        public virtual int IteracionNacimientoMejor { get; set; }
    }

    public class ValoresSalidaEjecucionRN : ValoresSalidaEjecucion
    {

    }
}
