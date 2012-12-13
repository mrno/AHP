using System;
using System.Collections.Generic;

namespace probaAHP
{
    public class Utils
    {
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






        public int MCM(params int[] numeros)
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
    
    public double AgregacionMediaGeometricaKExpertos(List<Int32> listaKValoraciones)
    {
        double resultado = 0 ;
        int exponente = listaKValoraciones.Count;

        foreach (int valor in listaKValoraciones)
        {
            resultado =resultado*valor;
        }

        return Math.Pow(resultado, exponente);

    }



    }
}