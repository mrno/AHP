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
        public double Aptitud(Individuo individuo)
        {
            return Math.Exp(-individuo.Inconsistencia);
        }
    }
}
