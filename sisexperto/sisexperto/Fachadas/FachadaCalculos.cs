using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathWorks.MATLAB.NET.Arrays;
using sisExperto;
using MathWorks.MATLAB.NET.Arrays;


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


    }



}
