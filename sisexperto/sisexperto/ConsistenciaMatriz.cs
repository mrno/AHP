using System;
using MathWorks.MATLAB.NET.Arrays;


namespace sisexperto
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

            int cant = 0;
            foreach (double item in doubleArray)
            {
                cant++;
            }
            cant--;
            cant = cant / 3;

            for (int i = 0; i < cant; i++)
            {
                doubleArray[i, 0] = doubleArray[i, 0] - 1;
                doubleArray[i, 1] = doubleArray[i, 1] - 1;
            }

            return doubleArray;
        }
    
    }
}
