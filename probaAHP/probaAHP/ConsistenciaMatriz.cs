using System;
using MathWorks.MATLAB.NET.Arrays;


namespace probaAHP
{
    public class ConsistenciaMatriz
    {

        MatlabUtils matlabUtils = new MatlabUtils();
        public Boolean calcularConsistencia(double[,] matriz)
        {


            Consistencia.Consistencia c = new Consistencia.Consistencia();
            MWNumericArray matlabNumericArray = (MWNumericArray)matlabUtils.MLArrayFromNetArray(matriz);

            MWLogicalArray result = (MWLogicalArray)c.calcConsist(matlabNumericArray);
            
            Boolean resultadoEntero = (Boolean)result;

            // LA CONVERSION ARROJA:
            // RESULTADO 1=VERDADERO, 0=FALSO.
            Boolean resultadoBoolean = Convert.ToBoolean(resultadoEntero);

            return resultadoBoolean;
        }
   
    
        public double[,] buscarMejoresConsistencia (double[,] matriz)
        {


            var mejorarConsistencia = new Mejora.Consistencia();
            MWNumericArray matlabNumericArray = (MWNumericArray)matlabUtils.MLArrayFromNetArray(matriz);


            MWNumericArray resultado = (MWNumericArray)mejorarConsistencia.impConsist(matlabNumericArray);

            

            double[,] doubleArray = (double[,])resultado.ToArray(MWArrayComponent.Real);



            return doubleArray;
        }
    
    }
}
