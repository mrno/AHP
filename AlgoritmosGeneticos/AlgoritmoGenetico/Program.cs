using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary;
using GALibrary.Persistencia;
using GALibrary.ProcesoGenetico;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.Complementos;

namespace AlgoritmoGenetico
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilidades.CalcularConsistencia(new double[3, 3]);
            
            const int cantidadSubConjuntosDe100Matrices = 5;
            //GenerarMatrices(cantidadSubConjuntosDe100Matrices);
            Evolucionar(150);
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

        private static void Evolucionar(int individuos)
        {
            int cantidad = 36000;
            int sesionId = 3;

            //using (var context = new GAContext())
            //{
            //    cantidad = context.Matrices.Include("MatrizCompleta").Count(x => x.MatrizCompleta != null);

            //    var sesion = new SesionExperimentacion
            //                     {
            //                         ModeloEvolutivo = "ModeloEvolutivoEstandar",
            //                         Individuos = individuos,

            //                         Seleccion = "SelectorElitista",
            //                         PorcentajeSeleccion = 0.1,

            //                         Cruza = "SelectorRuleta>CruzadorSimple",
            //                         PorcentajeCruza = 0,

            //                         Mutacion = "SelectorUniforme>MutadorSimple",
            //                         ProbabilidadMutacion = "ProbabilidadConvergencia",
            //                         PorcentajeMinimoMutacion = 0.0,
            //                         PorcentajeMaximoMutacion = 0.05,
            //                         CrecimientoPorcentajeMutacion = 0.001,

            //                         CondicionParada = "ParadaIteraciones:100&ParadaConvergencia:0.98",
            //                         ConvergenciaPoblacion = "ConvergenciaEstructura",
            //                         FuncionAptitud = "FuncionAptitudConsistenciaExponencial",
            //                     };

            //    context.Sesiones.Add(sesion);
            //    context.SaveChanges();

            //    sesionId = sesion.Id;
            //}

            //for (int i = 0; i < cantidad / 10; i++)
                for (int i = 29220; i < cantidad; i+=100)
            {
                Utilidades.CalcularConsistencia(new double[3, 3]);

                using (var context = new GAContext())
                {
                    var conjuntoIncompletas = context.Matrices
                        //.Include("MatrizCompleta.Filas.Celdas")
                        .Include("Filas.Celdas")
                        //.Include("MatricesIncompletas.Filas.Celdas")
                        .Include("Experimentos.MatrizMejorada.Filas.Celdas")
                        .Where(x => x.MatrizCompleta != null)
                        .OrderBy(x => x.Id)
                        //.Skip(i*10).Take(10).ToList();
                        .Skip(i).Take(100).ToList();
                    //Include("Experimentos").
                    var sesionExperimento = context.Sesiones.First(x => x.Id == sesionId);
                    
                    //if (sesionExperimento.Experimentos == null)
                    //    sesionExperimento.Experimentos = new List<ResultadoExperimento>();
                    
                    //var matriz = conjuntoIncompletas.First();
                    foreach (var matriz in conjuntoIncompletas)
                    {
                        var evolucion =
                            new Evolucion(matriz,
                                          sesionExperimento);

                        var experimento =
                            evolucion.Evolucionar();

                        if (matriz.Experimentos == null)
                            matriz.Experimentos =
                                new List<ResultadoExperimento>();

                        matriz.Experimentos.Add(experimento);
                        experimento.MatrizOriginal = matriz;

                        //sesionExperimento.Experimentos.Add(experimento);
                        experimento.SesionExperimentacion = sesionExperimento;
                        GC.Collect();
                    }
                    //Parallel.ForEach(conjuntoIncompletas, (matriz) =>
                    //                               {
                    //                                   var evolucion =
                    //                                       new Evolucion(matriz, 
                    //                                                     sesionExperimento);

                    //                                   var experimento =
                    //                                       evolucion.Evolucionar();

                    //                                   if (matriz.Experimentos == null)
                    //                                       matriz.Experimentos =
                    //                                           new List<ResultadoExperimento>();

                    //                                   matriz.Experimentos.Add(experimento);
                    //                                   experimento.MatrizOriginal = matriz;
                                                       
                    //                                   sesionExperimento.Experimentos.Add(experimento);
                    //                                   GC.Collect();
                    //                               });
                    context.SaveChanges();
                }
                GC.Collect();
            }
        }
    }
}
