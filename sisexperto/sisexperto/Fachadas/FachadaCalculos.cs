using System;
using System.Collections.Generic;
using MathWorks.MATLAB.NET.Arrays;
using sisExperto;

namespace sisexperto.Fachadas
{
    public sealed class FachadaCalculos
    {
        private static volatile FachadaCalculos instance;
        private static readonly object syncRoot = new Object();
        private readonly MatlabUtils _matlabutils = new MatlabUtils();
        private Consistencia.Consistencia c = new Consistencia.Consistencia();
        private Mejora.Consistencia mejorarConsistencia = new Mejora.Consistencia();
        private CalcularAHP.CalcularAHP calcularAhp = new CalcularAHP.CalcularAHP();
        private MatlabUtils matlabUtils = new MatlabUtils();


        private FachadaCalculos()
        {
        }

        public static FachadaCalculos Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new FachadaCalculos();
                    }
                }

                return instance;
            }
        }


        public double[,] calcularRanking(List<Double[,]> listaCriterioAlternativas)
        {            
            MWNumericArray vectCriterios = matlabUtils.ObtenerVectorCriteriosAHP(listaCriterioAlternativas);
            MWNumericArray superMatriz = matlabUtils.ObtenerSuperMatrizAlternativas(listaCriterioAlternativas);
            var mwArray = (MWNumericArray) calcularAhp.rankCalc(vectCriterios, superMatriz);
            double[,] resultado = matlabUtils.NetArrayFromMLArray(mwArray);

            return resultado;
        }

    



        public bool CalcularConsistencia(double[,] matriz)
        {
            
            MWNumericArray matlabNumericArray = _matlabutils.MLArrayFromNetArray(matriz);

            var result = (MWLogicalArray) c.calcConsist(matlabNumericArray);

            Boolean resultadoEntero = result;

            // LA CONVERSION ARROJA:
            // RESULTADO 1=VERDADERO, 0=FALSO.
            Boolean resultadoBoolean = Convert.ToBoolean(resultadoEntero);

            return resultadoBoolean;
        }


        public double[,] BuscarMejoresConsistencia(double[,] matriz)
        {
            //se le pasa una matriz consistente, hay que validar previamente con el metodo de arriba.
            // el resultado es una matriz de nx3.
            //  |i|j|valor-sugerido|
            // por ejemplo, |2|3|6| siginifica que en la posicion i=2 y j=3 se sugiere que vaya el valor 6.
            // con este cambio mejora la consistencia de la matriz.
            // esta matriz, el resultado del metodo. sugiere un valor para todos los valores de la matriz.
            // es decir, si es una matriz de 4x4, el metodo sugiere 16 valores.
            // estos valores estan ordenados en funcion de "que tanto mejora la consistencia"
            // el primer valor es el que mejor mejora la consistencia y asi sucesivamente.


            MWNumericArray matlabNumericArray = _matlabutils.MLArrayFromNetArray(matriz);


            var resultado = (MWNumericArray)mejorarConsistencia.impConsist(matlabNumericArray);


            var doubleArray = (double[,])resultado.ToArray(MWArrayComponent.Real);

            int cant = 0;
            foreach (double item in doubleArray)
            {
                cant++;
            }
            cant--;
            cant = cant / 3;

            for (int i = 0; i < cant; i++)
            {
                doubleArray[i, 0] = doubleArray[i, 0] - 1;
                doubleArray[i, 1] = doubleArray[i, 1] - 1;
            }

            return doubleArray;
        }

        public IEnumerable<double[]> BuscarSugerencias(double[,] p)
        {
            List<double[]> listaSugerencias = new List<double[]>();

            MWNumericArray matlabNumericArray = _matlabutils.MLArrayFromNetArray(p);

            var resultado = (MWNumericArray)mejorarConsistencia.impConsist(matlabNumericArray);

            var doubleArray = (double[,])resultado.ToArray(MWArrayComponent.Real);

            int cant = (doubleArray.Length - 1) / 3; // acá habría que ver por qué va el -1
            
            for (int i = 0; i < cant; i++)
            {
                var vector = new double[3]
                                    {   doubleArray[i,0] - 1, // número de fila normalizado (por eso el menos 1)
                                        doubleArray[i,1] - 1, // número de la columna normalizado
                                        doubleArray[i,2]};   // valor que se debe cambiar
                if (vector[0] < vector[1])
                    listaSugerencias.Add(vector);
                else listaSugerencias.Add(new double[3] { vector[1], vector[0], (1 / vector[2]) });
            }

            //var matriz = MatrizALista(p);

            //foreach (var item in listaSugerencias)
            //{
            //    if (matriz.Contains(item))
            //    {
            //        listaSugerencias.Remove(item);
            //    }
            //}

            return listaSugerencias;
        }

        public List<double[]> MatrizALista(double[,] matriz)
        {
            var dimension = matriz.GetLength(0);
            var lista = new List<double[]>();
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    lista.Add(new double[3] { i, j, matriz[i, j] });
                }
            }
            return lista;
        }
    }
}