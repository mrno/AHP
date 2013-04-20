using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary;
using GALibrary.Persistencia;
using GALibrary.ProcesoGenetico;
using GALibrary.ProcesoGenetico.Entidades;

namespace AlgoritmoGenetico
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cantidadSubConjuntosDe100Matrices = 5;
            //GenerarMatrices(cantidadSubConjuntosDe100Matrices);
            var a = EvolucionarSecuencial(0);
            //var b = EvolucionarParalelo(0);
        }
        
        private static void GenerarMatrices(int cantidadSubConjuntosDe100)
        {
            for (int dimension = 4; dimension < 10; dimension++) 
            {
                var nuevoConjuntoId = 0;
                using (var context = new GAContext())
                {
                    var conjunto = new ConjuntoOrdenN(dimension);
                    context.ConjuntosOrdenN.Add(conjunto);
                    context.SaveChanges();
                    nuevoConjuntoId = conjunto.Id;
                }
                GC.Collect();

                for (int j = 0; j < cantidadSubConjuntosDe100; j++)
                {
                    var conjuntos = ConjuntoOrdenN.GenerarConjuntosDiferenciadosPorNivelDeInconsistencia(100, dimension);
                    GC.Collect();

                    foreach (var conjuntoMatriz in conjuntos)
                    {
                        using (var context = new GAContext())
                        {
                            var conjuntoN = context.ConjuntosOrdenN.First(x => x.Id == nuevoConjuntoId);

                            if(conjuntoN.ConjuntosMatrices == null) conjuntoN.ConjuntosMatrices = new List<ConjuntoMatriz>();
                            
                            conjuntoN.ConjuntosMatrices.Add(conjuntoMatriz);
                            context.SaveChanges();
                        }
                        GC.Collect();
                    }
                }
            }
        }

        private static TimeSpan EvolucionarParalelo(int iteraciones)
        {
            //Estructura estructuraBase;
            //Estructura estructuraObjetivo;

            var context = new GAContext();

            //var matriz = context.Matrices.First(x => x.Id == 11798);

            //estructuraBase = new Estructura(matriz);
            //estructuraObjetivo = new Estructura(matriz.MatrizCompleta);

            var conjunto4 = context.ConjuntosOrdenN
                .Include("ConjuntosMatrices.Matrices.Filas.Celdas")
                .Include("ConjuntosMatrices.Matrices.MatricesIncompletas.Filas.Celdas")
                .First(x => x.Id == 6).ConjuntosMatrices.First(x => x.Id == 101).Matrices.Take(1).ToList();

            var resultado = new List<Individuo>();

            var inicio = DateTime.Now;

            Parallel.ForEach(conjunto4, (matriz) =>
                                            {
                                                var estructuraBase =
                                                    new Estructura(matriz.MatricesIncompletas.ElementAt(2));
                                                var estructuraObjetivo = new Estructura(matriz);

                                                var evolucion = new Evolucion(estructuraBase, estructuraObjetivo, 100);
                                                var individuo = evolucion.Evolucionar("ModeloEvolutivoEstandar");

                                                resultado.Add(individuo);
                                            });

            context.Dispose();
            GC.Collect();
            return DateTime.Now - inicio;


            //var evolucion = new Evolucion(estructuraBase, estructuraObjetivo, 100);
            //evolucion.Evolucionar("ModeloEvolutivoEstandar");
        }

        private static TimeSpan EvolucionarSecuencial(int iteraciones)
        {
            //Estructura estructuraBase;
            //Estructura estructuraObjetivo;

            var context = new GAContext();
            
            var conjunto4 = context.ConjuntosOrdenN
                .Include("ConjuntosMatrices.Matrices.Filas.Celdas")
                .Include("ConjuntosMatrices.Matrices.MatricesIncompletas.Filas.Celdas")
                .First(x => x.Id == 6).ConjuntosMatrices.First(x => x.Id == 101).Matrices.Take(1).ToList();

            var resultado = new List<Individuo>();

            var inicio = DateTime.Now;

            foreach (var matriz in conjunto4)
            {
                var estructuraBase = new Estructura(matriz.MatricesIncompletas.ElementAt(2));
                var estructuraObjetivo = new Estructura(matriz);

                var evolucion = new Evolucion(estructuraBase, estructuraObjetivo, 500);
                var individuo = evolucion.Evolucionar("ModeloEvolutivoEstandar");

                resultado.Add(individuo);
            }
            
            context.Dispose();
            GC.Collect();
            return DateTime.Now - inicio;

            //var evolucion = new Evolucion(estructuraBase, estructuraObjetivo, 100);
            //evolucion.Evolucionar("ModeloEvolutivoEstandar");
        }
    }
}
