using System;
using System.Collections.Generic;
using CalcularAHP;
using CalcularAHPNative;
using MathWorks.MATLAB.NET.Arrays;


namespace sisexperto
{
    public class CalculoAHP
    {


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
    }
}
