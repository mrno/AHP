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
    public class FuncionAptitudConsistenciaExponencial : IFuncionAptitud
    {
        public Estructura EstructuraBase { get; set; }
        public Estructura EstructuraObjetivo { get; set; }

        public double Aptitud(Individuo individuo)
        {
            return Math.Exp(-individuo.Inconsistencia);
        }

        public double AptitudObjetivo
        {
            get { return Math.Exp(-InconsistenciaObjetivo); }
        }

        public double InconsistenciaObjetivo
        {
            get
            {
                return Utilidades.CalcularConsistencia
                    (Utilidades.ConvertirVectorEnMatriz(EstructuraObjetivo.Vector));
            }
        }

        //public object Clone()
        //{
        //    return new FuncionAptitudConsistenciaExponencial { EstructuraBase = EstructuraBase, EstructuraObjetivo = EstructuraObjetivo };
        //}
    }
}
