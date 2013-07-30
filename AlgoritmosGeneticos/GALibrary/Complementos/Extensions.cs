using System;
using System.Collections.Generic;
using System.Linq;
using GALibrary.Persistencia;

namespace GALibrary.Complementos
{
    public static class Extensions
    {
        public static double Distancia(this double origen, double destino)
        {
            return Math.Pow((origen - destino), 2);
        }

        public static bool Entre(this double? valor, double cotaInferior, double cotaSuperior)
        {
            return (valor != null) && (cotaInferior <= valor) && (valor < cotaSuperior);
        }

        public static bool Entre(this double valor, double cotaInferior, double cotaSuperior)
        {
            return (cotaInferior <= valor) && (valor < cotaSuperior);
        }

        public static double PorcentajeCompleto(this double[] vector)
        {
            var longitud = vector.Length;
            var incompletos = vector.Count(x => x.Equals(CeldaMatriz.Incompleto));

            return (double)(longitud - incompletos)/longitud;
        }

        public static int CantidadValoresFaltantes(this double[] vector)
        {
            return vector.Count(x => x.Equals(CeldaMatriz.Incompleto));
        }

        public static double[] ValoresFaltantes(this double[] vector)
        {
            return (from c in vector
                    where c.Equals(CeldaMatriz.Incompleto)
                    select c).ToArray();
        }

        public static double[] ValoresCompletos(this double[] vector)
        {
            return (from c in vector
                    where !c.Equals(CeldaMatriz.Incompleto)
                    select c).ToArray();
        }

        public static double DesvioVectores(this int[] vector, int[] comparador)
        {
            return vector.DesvioVectoresNumeroElementos(comparador, vector.Length);
        }

        public static double DesvioVectoresNumeroElementos(this int[] vector, int[] comparador, int elementos)
        {
            elementos = elementos > vector.Length ? vector.Length : elementos;
            var salida = 0.0;
            for (int i = 0; i < elementos; i++)
            {
                if(vector.ElementAt(i) != comparador.ElementAt(i))
                {
                    salida++;
                }
            }
            return salida*100/elementos;
        }

        public static int[] OrdenElementosPorImportancia(this double[] vector)
        {
            var diccionario = new Dictionary<int, double>();
            for (int i = 0; i < vector.Length; i++)
            {
                diccionario.Add(i+1, vector.ElementAt(i));
            }
            return (from c in diccionario.OrderByDescending(x => x.Value)
                   select c.Key).ToArray();
        }

        public static double CalcularErrorRankings(this double[] rankingObtenido, double[] rankingOriginal)
        {
            var ordenFinal = rankingObtenido.OrdenElementosPorImportancia().ToList();
            var ordenInicial = rankingOriginal.OrdenElementosPorImportancia().ToList();

            var error = 0.0;
            var normalizador = 0.0;
            for (int i = 0; i < ordenFinal.Count; i++)
            {
                var ponderacion = 1/Math.Pow(2, i);
                normalizador += ponderacion;
                if(ordenFinal[i] != ordenInicial[i])
                {
                    var distancia = Math.Abs(i - ordenInicial.IndexOf(ordenFinal[i]));
                    error += distancia*ponderacion;
                }
            }
            return error/normalizador;
        }

        public static double CalcularErrorMaximo(this int orden)
        {
            var error = 0.0;
            var normalizador = 0.0;
            var distanciasMaximas = DistanciasMaximas(orden);
            for (int i = 0; i < orden; i++)
            {
                var ponderacion = 1/Math.Pow(2, i);
                normalizador += ponderacion;
                error+= distanciasMaximas[i]*ponderacion;
            }
            return error/normalizador;
        }

        public static int[] DistanciasMaximas(int dimension)
        {
            var distancias = new int[dimension];
            for (int i = 0; i < (double)dimension/2; i++)
            {
                distancias[i] = dimension - (2*i) - 1;
                distancias[dimension - i - 1] = dimension - (2*i) - 1;
            }
            return distancias;
        }
    }
}
