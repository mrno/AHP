﻿using System;
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

            MWNumericArray result = (MWNumericArray)c.calcConsist(matlabNumericArray);

            Int32 resultadoEntero = (Int32)result;

            // LA CONVERSION ARROJA:
            // RESULTADO 1=VERDADERO, 0=FALSO.
            Boolean resultadoBoolean = Convert.ToBoolean(resultadoEntero);

            return resultadoBoolean;
        }
   
    
        public double[,] buscarMejoresConsistencia (double[,] matriz)
        {


            var mejorarConsistencia = new Mejora.Mejora();
            MWNumericArray matlabNumericArray = (MWNumericArray)matlabUtils.MLArrayFromNetArray(matriz);


            MWNumericArray resultado = (MWNumericArray)mejorarConsistencia.mejora(matlabNumericArray);

            

            double[,] doubleArray = (double[,])resultado.ToArray(MWArrayComponent.Real);



            return doubleArray;
        }
    
    }
}
