using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using Consistencia;
using ConsistenciaNative;
using Mejora;
using MejoraNative;


namespace sisexperto
{
    public class DllHandler
    {

        public Boolean calcularConsistencia(double[,] matriz)
        {
            Consistencia.Class1 c = new Consistencia.Class1();
            MWArray result = (MWArray)c.consitencia((MWNumericArray)MLArrayFromNetArray(matriz));
            return false;
        }

        private MWNumericArray MLArrayFromNetArray(double[,] matriz)
        {
            MWNumericArray rdo = matriz;
            return rdo;
        }

        private double[,] NetArrayFromMLArray(MWNumericArray matriz)
        {

            double[,] rdo = (double[,])matriz.ToArray(MWArrayComponent.Real);
            return rdo;
        }

        public double[,] mejorar(double[,] matriz)
        {

            var mejora = new Mejora.Mejora();
            var result = (MWArray) mejora.mejora((MWNumericArray)MLArrayFromNetArray(matriz));
            
            return null;
        }
    }
}
