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

            MWArray mwArray = calcularAhp.calcularAHP(cellArray);
            var resultado = matlabUtils.NetArrayFromMLArray((MWNumericArray)mwArray);
            return resultado;
        }
    }
}
