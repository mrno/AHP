﻿using System;
using System.Collections.Generic;
using MathWorks.MATLAB.NET.Arrays;
using sisExperto;



namespace sisexperto.Fachadas
{
    
    public sealed class FachadaCalculos 
    {
        private static volatile FachadaCalculos instance;
        private static object syncRoot = new Object();
        private MatlabUtils _matlabutils = new MatlabUtils();
        

        private FachadaCalculos() { }

        public static FachadaCalculos Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new FachadaCalculos();
                }
            }

            return instance;
        }
    }
   
        
        public double[,] calcularRanking(List<Double[,]> listaCriterioAlternativas)
        {
            CalcularAHP.CalcularAHP calcularAhp = new CalcularAHP.CalcularAHP();
            MatlabUtils matlabUtils = new MatlabUtils();
            MWNumericArray vectCriterios = matlabUtils.ObtenerVectorCriterios(listaCriterioAlternativas);
            MWNumericArray superMatriz = matlabUtils.ObtenerSuperMatrizAlternativas(listaCriterioAlternativas);
            MWNumericArray mwArray = (MWNumericArray)calcularAhp.rankCalc(vectCriterios, superMatriz);
            var resultado = matlabUtils.NetArrayFromMLArray((MWNumericArray)mwArray);

            return resultado;
        }


        public bool CalcularConsistencia(double[,] matriz)
        {
            Consistencia.Consistencia c = new Consistencia.Consistencia();
            MWNumericArray matlabNumericArray = (MWNumericArray)_matlabutils.MLArrayFromNetArray(matriz);

            MWLogicalArray result = (MWLogicalArray)c.calcConsist(matlabNumericArray);

            Boolean resultadoEntero = (Boolean)result;

            // LA CONVERSION ARROJA:
            // RESULTADO 1=VERDADERO, 0=FALSO.
            Boolean resultadoBoolean = Convert.ToBoolean(resultadoEntero);

            return resultadoBoolean;
        }

        public double[,] buscarMejoresConsistencia(double[,] matriz)
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
            MWNumericArray matlabNumericArray = (MWNumericArray)_matlabutils.MLArrayFromNetArray(matriz);


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
