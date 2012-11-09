using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathWorks.MATLAB.NET.Arrays;
using sisExperto;

namespace sisexperto.Fachadas
{
    
    public sealed class FachadaCalculos 
    {
        private static volatile FachadaCalculos instance;
        private static object syncRoot = new Object();

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

    }

}
