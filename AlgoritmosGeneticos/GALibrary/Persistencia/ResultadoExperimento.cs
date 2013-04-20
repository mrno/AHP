using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.Persistencia
{
    public class ResultadoExperimento
    {
        public int Id { get; set; }
        public SesionExperimentacion SesionExperimentacion { get; set; }

        public ObjetoMatriz MatrizOriginal { get; set; }
        public ObjetoMatriz MatrizMejorada { get; set; }

        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

        public int IteracionesRealizadas { get; set; }
        public int IteracionNacimientoMejor { get; set; }
    }

    public class SesionExperimentacion
    {
        public int Id { get; set; }
        public ICollection<ResultadoExperimento> Experimentos { get; set; }

        public string ModeloEvolutivo { get; set; }
        public int Individuos { get; set; }

        public string Seleccion { get; set; }
        public double PorcentajeSeleccion { get; set; }

        public string Cruza { get; set; }
        public double PorcentajeCruza { get; set; }

        public string Mutacion { get; set; }
        public string ProbabilidadMutacion { get; set; }
        public double PorcentajeMaximoMutacion { get; set; }
        public double PorcentajeMinimoMutacion { get; set; }
        public double CrecimientoPorcentajeMutacion { get; set; }

        public string CondicionParada { get; set; }
        public string ConvergenciaPoblacion { get; set; }
        public string FuncionAptitud { get; set; }
    }
}
