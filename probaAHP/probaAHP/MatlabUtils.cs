﻿using System;
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
    }
}
