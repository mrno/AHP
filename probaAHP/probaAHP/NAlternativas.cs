using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto
{
    public class NAlternativas
    {
        public double[,] nAlternativas;

        public NAlternativas(int i)//i es la cantidad de alternativas
       {
           nAlternativas = new double[i,i];
       }

    }
}
