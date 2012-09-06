using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathWorks.MATLAB.NET.Arrays;
using Consistencia;
using ConsistenciaNative;

namespace probaAHP
{
    public class ConsistenciaMatriz
    {

       
        public Boolean calcularConsistencia(double[,] matriz)
        {
            MatlabUtils matlabUtils = new MatlabUtils();

            Consistencia.Class1 c = new Consistencia.Class1();
            MWNumericArray matlabNumericArray = (MWNumericArray)matlabUtils.MLArrayFromNetArray(matriz);

            MWNumericArray result = (MWNumericArray)c.consitencia(matlabNumericArray);

            Int32 resultadoEntero = (Int32)result;

            // LA CONVERSION ARROJA:
            // RESULTADO 1=VERDADERO, 0=FALSO.
            Boolean resultadoBoolean = Convert.ToBoolean(resultadoEntero);

            return resultadoBoolean;
        }
    }
}
