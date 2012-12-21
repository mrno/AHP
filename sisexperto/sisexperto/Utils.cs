using System;
using System.Collections.Generic;
using sisExperto;
using sisexperto.Entidades;

namespace probaAHP
{
    public class Utils
    {
        public void AgregacionCriterios(ValoracionIL resultado, double[,] rankAgregado)
        {
            int iAlternativa = 0;
            int denominador = resultado.AlternativasIL[0].ValorCriterios.Count;
            foreach (var VARIABLE in resultado.AlternativasIL)
            {

                foreach (var valor in VARIABLE.ValorCriterios)
                {
                    rankAgregado[iAlternativa, 0] += valor.ValorILNumerico;

                }
                rankAgregado[iAlternativa, 0] /= denominador;
                iAlternativa++;
            }
        }


        public void MultiplicarWCriterios(List<ValorCriterio> listCriterio )
        {
            
            MatlabUtils matlabUtils = new MatlabUtils();
            List<double[,]> list = new List<double[,]>();
            list.Add(GenerarMatrizDesdeLista(listCriterio));


            var resultado = matlabUtils.NetArrayFromMLArray(matlabUtils.ObtenerVectorCriteriosAHP(list));
            int i = 0;
            foreach (ValorCriterio valorCriterio in listCriterio)
            {
                valorCriterio.ValorILNumerico *= resultado[i, 0];
                i++;
            }

        }


        public double[,] GenerarMatrizDesdeLista(List<ValorCriterio> list )
        {
            int dimension = list.Count;
            var matriz = new double[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (i == j)
                        matriz[i, j] = 1;
                    if (i > j)
                        matriz[i, j] = (double)1.0 / matriz[j, i];
                }
            }

            return matriz;
        }
        public double[,] NormalizarIlFinal(double[,] rank)
        {
            double sum = 0;

            for (int i = 0; i < rank.GetLength(0); i++)
            {
                sum += rank[i, 0];
            }

            for (int i = 0; i < rank.GetLength(0); i++)
            {
                rank[i, 0] = rank[i, 0] / sum;
            }

            return rank;
        }

    public void Productoria(double[,] salida, double[,] entrada)
        {
            int cantidad = entrada.GetLength(1);
            for (int i = 0; i < cantidad; i++)
            {
                for (int j = 0; j < cantidad; j++)
                {
                    salida[i, j] *= entrada[i, j];
                }
            }
        }

    public void Unar(double[,] salida, int cantidad)
        {
            for (int j = 0; j < cantidad; j++)
            {
                for (int k = 0; k < cantidad; k++)
                {
                    salida[j, k] = 1;
                }
            }
        }

    public void Cerar(double[,] salida, int cantidad)
        {
            for (int j = 0; j < cantidad; j++)
            {
                for (int k = 0; k < cantidad; k++)
                {
                    salida[j, k] = 0;
                }
            }
        }

    public int Mcm(params int[] numeros)
        {
            int maximo = 1;
            int tmp = 0;
            foreach (int b in numeros)
            {
                numeros[tmp] = Math.Abs(b);
                maximo = maximo * numeros[tmp];
                tmp++;
            }
            int resultado = 1;
            for (int i = 2; i <= maximo; i++)
            {
                bool a = true;
                foreach (int b in numeros)
                {
                    if (i % b != 0)
                    {
                        a = false;
                    }
                }
                if (a)
                {
                    resultado = i;
                    break;
                }
            }
            return resultado;
        }
    
    public int ExtrapoladoAConjuntoNormalizado(Int32 valoracion, Int32 CardinalidadCEN, Int32 CardinalidadCEExpertoK)
    {
        return (valoracion*CardinalidadCEN)/CardinalidadCEExpertoK;
    }

    public double InversaExtrapoladoAConjuntoNormalizado(Int32 valoracionNormalizada, Int32 CardinalidadCEN, Int32 CardinalidadCEExpertoK)
    {
        return (double)(valoracionNormalizada * CardinalidadCEExpertoK) / CardinalidadCEN;
    }
    
    public void AgregacionMediaGeometricaKExpertos(ValoracionIL resultado, Int32 exponente)
    {
        double _exponente = (double) 1/exponente;
        foreach (AlternativaIL alternativaIl in resultado.AlternativasIL)
        {
            foreach (ValorCriterio valor in alternativaIl.ValorCriterios)
            {
                valor.ValorILNumerico = Math.Pow(valor.ValorILNumerico, _exponente);
            }
        }
    
    }



        public ValoracionIL ObtenerEstructuraRdo(ValoracionIL valoracionIlingreso, bool ConPeso)
        {

            ValoracionIL valoracionIlSalida = new ValoracionIL();


            List<AlternativaIL> listAlternativaIls = new List<AlternativaIL>();
            foreach (AlternativaIL alternativaIl in valoracionIlingreso.AlternativasIL)
            {
                AlternativaIL alternativaIls = new AlternativaIL();
                List<ValorCriterio> listaValorCriterio = new List<ValorCriterio>();

                foreach (ValorCriterio valorCriterio in alternativaIl.ValorCriterios)
                {
                    ValorCriterio valorCriterios = new ValorCriterio();

                    if (ConPeso)
                    {
                        valorCriterios.ValorILNumerico = 0;    
                    }
                    else
                    {
                        valorCriterios.ValorILNumerico = 1;

                    }
                    
                    listaValorCriterio.Add(valorCriterios); 
                }
                alternativaIls.ValorCriterios = listaValorCriterio;
                listAlternativaIls.Add(alternativaIls);
            }
            valoracionIlSalida.AlternativasIL = listAlternativaIls;
            return valoracionIlSalida;
        }

    }
}