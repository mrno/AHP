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
    [ElementoAG(TipoElementoAG.FuncionAptitud, "FuncionAptitudModificarValores")]
    public class FuncionAptitudModificarValores : IFuncionAptitud
    {
        public Estructura EstructuraBase { get; set; }
        public double Aptitud(Individuo individuo)
        {
            var errorCR = 10.0 / (Math.Exp(10 * (individuo.Inconsistencia - 0.15))+1);
            var errorModificacion = 1.0/(1 + Math.Pow(individuo.Error, 3));
            return errorCR * errorModificacion;
        }

        //public double Aptitud(Individuo individuo)
        //{
        //    var errorCR = 1.0 / (Math.Exp(40 * individuo.Inconsistencia - 7.2) + 1);
        //    var errorModificacion = 1.0 / (1 + individuo.Error);
        //    return errorCR * errorModificacion;
        //}

        //public double Aptitud(Individuo individuo)
        //{
        //    var errorCR = 1.0 / (Math.Exp(40 * individuo.Inconsistencia - 7.2) + 1);
        //    var errorModificacion = 1.0;// / (1 + Math.Pow(individuo.Error, 5));
        //    return errorCR * errorModificacion;
        //}

        //public double Aptitud(Individuo individuo)
        //{
        //    var errorCR = 1.0/(Math.Exp(40*individuo.Inconsistencia - 7.2) + 1);
        //    var errorModificacion = 1.0 / (1 + Math.Pow(individuo.Error, 5));
        //    return errorCR * errorModificacion;
        //}
    }
}
