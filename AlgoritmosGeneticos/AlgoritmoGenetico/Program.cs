using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary;
using GALibrary.Persistencia;

namespace AlgoritmoGenetico
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cantidad = 500;
            //GenerarMatrices(cantidad);
            Evolucionar(0);
        }

        private static void GenerarMatrices(int cantidad)
        {
            for (int i = 4; i < 10; i++)
            {
                using (var context = new GAContext())
                {
                    var conjunto = new ConjuntoMatriz(cantidad, i);
                    context.ConjuntoMatrices.Add(conjunto);

                    context.SaveChanges();
                }
            }
        }

        private static void Evolucionar(int iteraciones)
        {
            var consistencia1 = 0.0;
            var t1 = new TimeSpan();

            var consistencia2 = 0.0;
            var t2 = new TimeSpan();

            var consistencia3 = 0.0;
            var t3 = new TimeSpan();

            using (var context = new GAContext())
            {
                var numero = context.Matrices.Count();
            }

            using (var context = new GAContext())
            {
                var inicio = DateTime.Now;

                consistencia2 = (from c in context.Matrices
                                 where c.Inconsistencia != null
                                 select (double)c.Inconsistencia).Sum();
                t2 = DateTime.Now - inicio;
            }

            using (var context = new GAContext())
            {
                var inicio = DateTime.Now;
                var lista = context.Matrices.Where(x => x.Inconsistencia != null);
                Parallel.ForEach(lista, (x) =>
                                                                                            {
                                                                                                consistencia1 +=
                                                                                                    (double)
                                                                                                    x.Inconsistencia;
                                                                                            });
                t1 = DateTime.Now - inicio;
            }

            

            using (var context = new GAContext())
            {
                var inicio = DateTime.Now;

                foreach (var objetoMatriz in context.Matrices.Where(x => x.Inconsistencia != null))
                {
                    consistencia3 += (double) objetoMatriz.Inconsistencia;
                }
                t3 = DateTime.Now - inicio;
            }
        }
    }
}
