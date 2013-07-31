using GALibrary.Complementos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.Persistencia
{
    public class ResultadoExperimento
    {
        public virtual int Id { get; set; }
        public virtual SesionExperimentacion SesionExperimentacion { get; set; }

        public virtual ObjetoMatriz MatrizOriginal { get; set; }
        public virtual ObjetoMatriz MatrizMejorada { get; set; }

        public virtual double Error { get; set; }
        public virtual double ErrorRelativo { get; set; }
        public virtual double Cambios { get; set; }
        
        public virtual DateTime Inicio { get; set; }
        public virtual DateTime Fin { get; set; }

        public virtual int IteracionesRealizadas { get; set; }
        public virtual int IteracionNacimientoMejor { get; set; }
    }

    public class SesionExperimentacion
    {
        public virtual int Id { get; set; }
        public virtual ICollection<ResultadoExperimento> Experimentos { get; set; }

        public virtual string ModeloEvolutivo { get; set; }
        public virtual int Individuos { get; set; }

        public virtual string Seleccion { get; set; }
        public virtual double PorcentajeSeleccion { get; set; }

        public virtual string Cruza { get; set; }
        public virtual double PorcentajeCruza { get; set; }

        public virtual string Mutacion { get; set; }
        public virtual string ProbabilidadMutacion { get; set; }
        public virtual double PorcentajeMaximoMutacion { get; set; }
        public virtual double PorcentajeMinimoMutacion { get; set; }
        public virtual double CrecimientoPorcentajeMutacion { get; set; }

        public virtual string CondicionParada { get; set; }
        public virtual string ConvergenciaPoblacion { get; set; }
        public virtual string FuncionAptitud { get; set; }
    }
}
