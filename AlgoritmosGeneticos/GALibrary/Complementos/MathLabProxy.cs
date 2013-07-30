using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsistenciaCR;
using MathWorks.MATLAB.NET.Arrays;

namespace GALibrary.Complementos
{
    public class MathLabProxy
    {
        private Dictionary<double[,], double> _obtainedCRs;
        private MWNumericArray _matlabNumericArray;
        private calcConsistenciaCR _consistenciaCR;

        public MathLabProxy()
        {
            _consistenciaCR = new calcConsistenciaCR();
            _obtainedCRs = new Dictionary<double[,], double>();
        }

        private double CalcularCR(double[,] matriz)
        {
            _matlabNumericArray = matriz;
            var mwNumericArray = _consistenciaCR.calcConsistCR(_matlabNumericArray) as MWNumericArray;
            if (mwNumericArray != null)
            {
                var cr = mwNumericArray.ToScalarDouble();
                return (cr > 0) ? cr : 0;
            }
            return Double.MaxValue;
        }

        public double ObtenerCR(double[,] matriz)
        {
            var dictionaryElement = _obtainedCRs.FirstOrDefault(x => x.Key == matriz);
            if (dictionaryElement.Key == null)
            {
                var valor = CalcularCR(matriz);
                _obtainedCRs.Add(matriz, valor);
                return valor;
            }
            return dictionaryElement.Value;
        }
    }
}
