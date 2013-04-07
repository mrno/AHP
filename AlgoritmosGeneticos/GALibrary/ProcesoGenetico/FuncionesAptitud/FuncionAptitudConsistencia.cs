using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.Complementos;
using GALibrary.Persistencia;

namespace GALibrary.ProcesoGenetico.FuncionesAptitud
{
    public class FuncionAptitudConsistencia : IFuncionAptitud
    {
        public Estructura EstructuraBase { get; set; }
        public Estructura EstructuraObjetivo { get; set; }

        public double Aptitud(Individuo individuo)
        {
            return 1.0 - individuo.Inconsistencia;
        }

        public double AptitudObjetivo
        {
            get { return 1.0 - Utilidades.CalcularConsistencia
                (Utilidades.ConvertirVectorEnMatriz(EstructuraObjetivo.Vector)); }
        }

        public object Clone()
        {
            return new FuncionAptitudConsistencia();
        }
    }
}
