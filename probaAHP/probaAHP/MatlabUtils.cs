using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathWorks.MATLAB.NET.Arrays;

namespace probaAHP
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

            double[,] rdo = (double[,])matriz.ToArray(MWArrayComponent.Real);
            return rdo;
        }

       
        public MWCellArray NetListToMLCellArray(List<Double[,]> input )
        {
           MWCellArray cellArray = new MWCellArray();
          //  MWNumericArray numericArray = new MWNumericArray();
           

            for (int i = 1; i < input.Count+1; i++)
            {
                cellArray[i] = ((MWNumericArray)input[i]);
            }

            return cellArray;
        }


    }
}
