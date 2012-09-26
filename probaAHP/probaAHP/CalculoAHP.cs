using System;
using System.Collections.Generic;
using CalcularAHP;
using CalcularAHPNative;
using MathWorks.MATLAB.NET.Arrays;


namespace probaAHP
{
    public class CalculoAHP
    {


        public double[,] calcularRanking(List<Double[,]> listaCriterioAlternativas )
        {
            CalcularAHP.CalcularAHP calcularAhp = new CalcularAHP.CalcularAHP();
            MatlabUtils matlabUtils = new MatlabUtils();
            MWCellArray cellArray = matlabUtils.NetListToMLCellArray(listaCriterioAlternativas);
            
            
            MWCellArray mwca = new MWCellArray(3);
            
            double[,] a = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            mwca[1] = matlabUtils.MLArrayFromNetArray(a);

            double[,] b = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            mwca[2] = matlabUtils.MLArrayFromNetArray(b);

            double[,] c = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            mwca[3] = matlabUtils.MLArrayFromNetArray(c);




            MWNumericArray mwArray = (MWNumericArray)calcularAhp.rankCalc(cellArray);
            var resultado = matlabUtils.NetArrayFromMLArray((MWNumericArray)mwArray);
            return resultado;
        }
    }
}
