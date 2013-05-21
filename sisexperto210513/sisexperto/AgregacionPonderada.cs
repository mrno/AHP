 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace probaAHP
{
    public class AgregacionPonderada
    {


        public double[,] agregar(List<KRankPonderado> listaKRanking)
        {
            Utils utils= new Utils();
             normalizarPesos(listaKRanking);
             int dimension = listaKRanking[1].KRanking.GetLength(0);
            
            double[,] rankAgregado = new double[dimension, 1];
            foreach (var kRankPonderado in listaKRanking)
            {

                for (int i = 0; i < dimension; i++)
                {
                   
                        rankAgregado[i, 0] += kRankPonderado.KRanking[i, 0]*kRankPonderado.PesoPonderado;
 
                }

            }
            return rankAgregado;
        }


        private void normalizarPesos(List<KRankPonderado> listaKRanking)
        {
            Int32 sum = 0;
            foreach (var kRankPonderado in listaKRanking)
            {
                sum += kRankPonderado.Peso;
            }


            foreach (var kRankPonderado in listaKRanking)
            {
                double vble;
                vble = (double)kRankPonderado.Peso / (double)sum;
                kRankPonderado.PesoPonderado = vble;

            }


        }
    }
}
