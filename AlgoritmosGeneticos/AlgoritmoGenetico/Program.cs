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
            GenerarMatrices(cantidadSubConjuntosDe100Matrices);
            //Evolucionar(0);
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

        private static void Evolucionar(int iteraciones)
        {
            Estructura estructuraBase;
            Estructura estructuraObjetivo;

            using (var context = new GAContext())
            {
                var matriz = context.Matrices.First(x => x.Id == 11798);

                estructuraBase = new Estructura(matriz);
                estructuraObjetivo = new Estructura(matriz.MatrizCompleta);
            }

            var evolucion = new Evolucion(estructuraBase, estructuraObjetivo, 100);
            evolucion.Evolucionar("ModeloEvolutivoEstandar");
        }
    }
}
