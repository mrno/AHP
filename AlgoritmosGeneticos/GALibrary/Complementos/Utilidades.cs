using System;
using System.Linq;
using GALibrary.Persistencia;

namespace GALibrary.Complementos
{
    public static class Utilidades
    {
        public static readonly Random Random = new Random();

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
            var fraccionario = false;
            var proximo = 1.0;
            if (valor < 1)
            {
                fraccionario = true;
                valor = 1.0 / valor;
            }

            for (int i = 2; i <= 9; i++)
            {
                if (valor.Distancia(i) < valor.Distancia(proximo))
                {
                    proximo = i;
                }
            }

            if (fraccionario)
            {
                return 1 / proximo;
            }
            return proximo;
        }


        public static double ValorAleatorioEscalaFundamental()
        {
            var valor = Random.Next(1, 18);
            if (valor < 10)
                return valor;

            return 1.0 / (valor - 8);
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
    }
}
