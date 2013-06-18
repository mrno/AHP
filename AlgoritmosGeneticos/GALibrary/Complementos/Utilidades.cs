using System;
using System.Linq;
using ConsistenciaCR;
using GALibrary.Persistencia;
using MathWorks.MATLAB.NET.Arrays;

namespace GALibrary.Complementos
{
    public static class Utilidades
    {
        public static readonly Random Random = new Random();

        public static readonly double[] EscalaSaaty = new double[]
                                                          {
                                                              1.0/9, 1.0/8, 1.0/7, 1.0/6, 
                                                              1.0/5, 1.0/4, 1.0/3, 1.0/2, 
                                                              1, 2, 3, 4, 5, 6, 7, 8, 9
                                                          };

        //public static int Llamadas { get; set; }

        public static double[] ConvertirMatrizEnVector(double[,] matriz)
        {
            var dimension = matriz.GetLength(0);
            var vector = new double[CalcularLongitudVector(dimension)];

            var posicion = 0;
            for (int fila = 0; fila < dimension - 1; fila++)
            {
                for (int columna = fila + 1; columna < dimension; columna++)
                {
                    vector[posicion] = matriz[fila, columna];
                    posicion++;
                }
            }

            return vector;
        }

        public static double[,] ConvertirVectorEnMatriz(double[] vector)
        {
            var longitud = vector.GetLength(0);
            var dimension = CalcularDimensionMatriz(longitud);

            var matriz = new double[dimension, dimension];

            var posicion = 0;
            for (int fila = 0; fila < dimension; fila++)
            {
                matriz[fila, fila] = 1;
                for (int columna = fila + 1; columna < dimension; columna++)
                {
                    matriz[fila, columna] = vector[posicion];
                    matriz[columna, fila] = 1.0 / vector[posicion];
                    posicion++;
                }
            }

            return matriz;
        }

        public static int CalcularLongitudVector(int dimension)
        {
            //if (dimension == 0)
            //    return 0;

            //return dimension + CalcularLongitudVector(dimension - 1);

            return dimension * (dimension - 1) / 2;
        }

        public static int CalcularDimensionMatriz(int longitud)
        {
            return (int)(Math.Floor(Math.Sqrt(longitud * 2)) + 1);
        }

        public static double[] GenerarAutovectorNormalizado(int dimension)
        {
            var autovector = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                autovector[i] = Random.NextDouble();
            }

            var total = autovector.Sum();

            for (int i = 0; i < dimension; i++)
            {
                autovector[i] /= total;
            }

            return autovector;
        }

        public static double[,] GenerarMatrizPorAutovector(double[] autovector)
        {
            var dimension = autovector.Length;
            var matriz = new double[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    matriz[i, j] = autovector[i] / autovector[j];
                }
            }

            return matriz;
        }

        public static double[,] AproximarMatriz(double[,] matriz)
        {
            var dimension = matriz.GetLength(0);
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    matriz[i, j] = AproximarSaaty(matriz[i, j]);
                }
            }
            return matriz;
        }

        public static double AproximarSaaty(double valor)
        {
            var proximo = 1.0;

            if (valor < 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (valor.Distancia(EscalaSaaty[i]) < valor.Distancia(proximo))
                    {
                        proximo = EscalaSaaty[i];
                    }
                }
            }
            else
            {
                for (int i = 9; i < 17; i++)
                {
                    if (valor.Distancia(EscalaSaaty[i]) < valor.Distancia(proximo))
                    {
                        proximo = EscalaSaaty[i];
                    }
                }
            }
            
            return proximo;
        }


        public static double ValorAleatorioEscalaFundamental()
        {
            var indice = Random.Next(0, 17);
            return EscalaSaaty[indice];
        }

        public static double[,] GenerarMatrizConsistente(int dimension)
        {
            var autovector = GenerarAutovectorNormalizado(dimension);
            return AproximarMatriz(GenerarMatrizPorAutovector(autovector));
        }

        public static double[,] GenerarMatrizConValoresFaltantes(double[] vector, int valoresFaltantes)
        {
            while (vector.Count(x => x.Equals(CeldaMatriz.Incompleto)) < valoresFaltantes)
            {
                vector[Random.Next(0, vector.Length)] = CeldaMatriz.Incompleto;
            }
            return ConvertirVectorEnMatriz(vector);
        }

        public static double CalcularConsistencia(double[,] matriz)
        {
            //Llamadas++;
            //return .5;

            MWNumericArray matlabNumericArray = matriz;
            var c = new calcConsistenciaCR();
            var mwNumericArray = c.calcConsistCR(matlabNumericArray) as MWNumericArray;
            if (mwNumericArray != null)
            {
                var cr = mwNumericArray.ToScalarDouble();
                return (cr > 0) ? cr : 0;
            }
            return Double.MaxValue;
        }

        public static double[] CombinarEstructuraConIndividuo(double[] estructura, double[] individuo)
        {
            if(!estructura.Any(x => x.Equals(CeldaMatriz.Incompleto)))
            {
                return individuo;
            }

            var longitudBase = estructura.Length;
            var resultado = estructura.Clone() as double[];
            var posicion = 0;
            for (int i = 0; i < longitudBase; i++)
            {
                if (estructura[i].Equals(CeldaMatriz.Incompleto))
                {
                    resultado[i] = individuo[posicion];
                    posicion++;
                }
            }
            return resultado;
        }

        public static string ConcatenarCadenasConFlechas(string[] cadenas)
        {
            var resultado = "";
            for (int i = 0; i < cadenas.Length; i++)
            {
                resultado += cadenas[0] + " -> ";
            }
            return resultado.Remove(0, resultado.Length - 4);
        }
    }
}
