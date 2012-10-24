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
            //se le pasa una matriz consistente, hay que validar previamente con el metodo de arriba.
            // el resultado es una matriz de nx3.
            //  |i|j|valor-sugerido|
            // por ejemplo, |2|3|6| siginifica que en la posicion i=2 y j=3 se sugiere que vaya el valor 6.
            // con este cambio mejora la consistencia de la matriz.
            // esta matriz, el resultado del metodo. sugiere un valor para todos los valores de la matriz.
            // es decir, si es una matriz de 4x4, el metodo sugiere 16 valores.
            // estos valores estan ordenados en funcion de "que tanto mejora la consistencia"
            // el primer valor es el que mejor mejora la consistencia y asi sucesivamente.

            var mejorarConsistencia = new Mejora.Consistencia();
            MWNumericArray matlabNumericArray = (MWNumericArray)matlabUtils.MLArrayFromNetArray(matriz);


            MWNumericArray resultado = (MWNumericArray)mejorarConsistencia.impConsist(matlabNumericArray);

            

            double[,] doubleArray = (double[,])resultado.ToArray(MWArrayComponent.Real);

            //int cant = 0;
            //foreach (double item in doubleArray)
            //{
            //    cant++;
            //}
            //cant--;
            //cant = cant / 3;

            //for (int i = 0; i < cant; i++)
            //{
            //    doubleArray[i, 0] = doubleArray[i, 0] - 1;
            //    doubleArray[i, 1] = doubleArray[i, 1] - 1;
            //}

            return doubleArray;
        }
    
    }
}
