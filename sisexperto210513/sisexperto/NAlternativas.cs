using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisExperto
{
    public class NAlternativas
    {
        public double[,] nAlternativas;

        public NAlternativas(int i)//i es la cantidad de Alternativas
        {
            nAlternativas = new double[i, i];
        }

        //public NAlternativas(double[,] matrix)
        //{
        //    nAlternativas = matrix;
        //}

    }
}
