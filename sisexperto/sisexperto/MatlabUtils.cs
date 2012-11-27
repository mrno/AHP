using System;
using System.Collections.Generic;
using MathWorks.MATLAB.NET.Arrays;

namespace sisExperto
{
    public class MatlabUtils
    {
        public MWNumericArray MLArrayFromNetArray(double[,] matriz)
        {
            MWNumericArray rdo = matriz;
            return rdo;
        }


        public double[,] NetArrayFromMLArray(MWNumericArray matriz)
        {
            var rdo = (double[,]) matriz.ToArray(MWArrayComponent.Real);
            return rdo;
        }


        public MWCellArray NetListToMLCellArray(List<Double[,]> input)
        {
            var cellArray = new MWCellArray(input.Count);
            //  MWNumericArray numericArray = new MWNumericArray();


            for (int i = 1; i < input.Count + 1; i++)
            {
                cellArray[i] = ((MWNumericArray) input[i - 1]);
            }

            return cellArray;
        }


        //El siguiente metodo recibe una matriz y devuelve un vector.

        public MWNumericArray ObtenerVectorCriterios(List<double[,]> lista)
        {
            var vectCalc = new VectCalc.VectCalc();
            Double[,] matrizCriterios = lista[0];
            MWNumericArray mtArray = MLArrayFromNetArray(matrizCriterios);

            var rdo = (MWNumericArray) vectCalc.vectCalc(mtArray);

            return rdo;
        }


        public MWNumericArray ObtenerSuperMatrizAlternativas(List<double[,]> lista)
        {
            var vectCalc = new VectCalc.VectCalc();
            int cantidad = lista.Count - 1;
            var matrizSalida = new double[lista.Count,cantidad];
            var preMatriz = new double[,] {};


            for (int i = 0; i < cantidad; i++)
            {
                MWNumericArray mlNArray = MLArrayFromNetArray(lista[i + 1]);
                var preRdo = (MWNumericArray) vectCalc.vectCalc(mlNArray);

                preMatriz = NetArrayFromMLArray(preRdo);

                for (int j = 0; j < cantidad; j++)
                {
                    matrizSalida[j, i] = preMatriz[j, 0];
                }
            }

            MWNumericArray rdoFinal = MLArrayFromNetArray(matrizSalida);

            return rdoFinal;
        }


        private Double[,] cerarMatriz(Double[,] input, Int32 cant)
        {
            for (int i = 0; i < cant; i++)
            {
                for (int j = 0; j < cant + 1; j++)
                {
                    input[i, j] = 0;
                }
            }

            return input;
        }
    }
}