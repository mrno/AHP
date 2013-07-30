using System;
using System.Collections.Generic;
using System.Globalization;
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
            //Utilidades.CalcularConsistencia(new double[3, 3]);

            //using (var context = new GAContext())
            //{
            //    var conjuntos = context.ConjuntosOrdenN.Include("ConjuntosMatrices.Matrices.MatricesIncompletas").ToList();
            //}

            //const int cantidadSubConjuntosDe100Matrices = 5;

            //GenerarMatricesLimiteConsistencia(cantidadSubConjuntosDe100Matrices);
            //GenerarMatrices(cantidadSubConjuntosDe100Matrices);
            //CompletarMatrices();
            //CalcularError();
            //VerConjuntos();
            //ProbarUna(100);
            EvolucionarConsistentes(200);
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

        private static void GenerarMatricesLimiteConsistencia(int cantidadSubConjuntosDe100)
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
                    var conjuntos = ConjuntoOrdenN.GenerarConjuntosAlLimiteDeLaInconsistencia(100, dimension);
                    GC.Collect();

                    foreach (var conjuntoMatriz in conjuntos)
                    {
                        using (var context = new GAContext())
                        {
                            var conjuntoN = context.ConjuntosOrdenN.First(x => x.Id == nuevoConjuntoId);

                            if (conjuntoN.ConjuntosMatrices == null) conjuntoN.ConjuntosMatrices = new List<ConjuntoMatriz>();

                            conjuntoN.ConjuntosMatrices.Add(conjuntoMatriz);
                            context.SaveChanges();
                        }
                        GC.Collect();
                    }
                }
            }
        }

        private static void CalcularError()
        {
            for (int i = 0; i < 1; i++)
            {
                using (var context = new GAContext())
                {
                    
                    var experimentos = context.Sesiones.Include("Experimentos.MatrizMejorada.Filas.Celdas")
                    .Include("Experimentos.MatrizOriginal.Filas.Celdas")
                    .First(x => x.Id == 1002).Experimentos.OrderBy(x => x.Id).Skip(0).Take(1500).ToList();

                    var modificacionesAceptables = experimentos
                        .Select(x => Utilidades.CalcularErrorMagnitud(x.MatrizOriginal.Vector, x.MatrizMejorada.Vector));
                    var media = (double)modificacionesAceptables.Average();
                    var varianza = (from c in modificacionesAceptables
                                    select Math.Pow((double) c - media, 2)).Sum()/1500;
                    
                } 
            }
        }

        private static void CompletarMatrices()
        {
            //var cantidad = 0;
            //using (var context = new GAContext())
            //{
            //    cantidad = context.Matrices.Count(x => x.Completitud == null);
            //}

            //for (int i = 0; i < cantidad; i+= 1000)
            //{
            //    using (var context = new GAContext())
            //    {
            //        var asd = (from c in context.Matrices.Include("Filas.Celdas")
            //                       .OrderBy(x => x.Id).Skip(i).Take(1000)
            //                   select c);
            //        foreach (var objetoMatriz in asd)
            //        {
            //            objetoMatriz.Completitud = objetoMatriz.PorcentajeCompleta;
            //        }
            //        context.SaveChanges();
            //    }
            //}
            var context = new GAContext();
            var matrices = context.Matrices.Include("Filas.Celdas").Where(x => x.Completitud == null).ToList();
            foreach (var matrix in matrices)
            {
                matrix.Completitud = matrix.PorcentajeCompleta;
            }
            context.SaveChanges();
        }

        private static void VerConjuntos()
        {
            var iDs = new List<int>();
            using (var context = new GAContext())
            {
                var conjuntosN = context.ConjuntosOrdenN.Include("ConjuntosMatrices").ToList();
                foreach(var conjuntoN in conjuntosN)
                {
                    iDs.AddRange(
                        conjuntoN.ConjuntosMatrices
                            .Where(x => x.NivelInconsistencia == NivelInconsistencia.Consistente)
                            .Select(x => x.Id));
                }
            }
            iDs.Reverse();
            foreach (var iD in iDs)
            {
                using (var context = new GAContext())
                {
                    var matrices = context.ConjuntoMatrices.Include("Matrices.Filas.Celdas")
                        .Include("Matrices.MatricesIncompletas.Filas.Celdas")
                        .First(x => x.Id == iD).Matrices.ToList();
                    var max = matrices.Max(x => x.Inconsistencia);
                    var matriz = matrices.First(x => x.Inconsistencia == max);
                }
            }

        }

        private static void ProbarUna(int individuos)
        {
            using (var context = new GAContext())
            {
                var matriz = context.Matrices
                    .Include("MatricesIncompletas.Filas.Celdas")
                    .Include("Filas.Celdas")
                    .First(x => x.Id == 44945).MatricesIncompletas.Last();

                var sesion = new SesionExperimentacion
                {
                    ModeloEvolutivo = "ModeloEvolutivoEstandar",
                    Individuos = individuos,

                    Seleccion = "SelectorElitista",
                    PorcentajeSeleccion = 0.1,

                    Cruza = "SelectorRango>CruzadorTransitivoDeTres",
                    PorcentajeCruza = 0,

                    Mutacion = "SelectorUniforme>MutadorSimple",
                    ProbabilidadMutacion = "ProbabilidadConvergencia",
                    PorcentajeMinimoMutacion = 0.0,
                    PorcentajeMaximoMutacion = 0.05,
                    CrecimientoPorcentajeMutacion = 0.001,

                    CondicionParada = "ParadaIteraciones:500&ParadaConsistencia:" + matriz.MatrizCompleta.Inconsistencia.ToString(),
                    ConvergenciaPoblacion = "ConvergenciaEstructura",
                    FuncionAptitud = "FuncionAptitudModificarValores",
                };

                //var matrices = context.Matrices
                //        .Include("MatrizCompleta")
                //        .Include("Filas.Celdas")
                //        .Include("Experimentos.MatrizMejorada.Filas.Celdas")
                //        .Where(x => x.MatrizCompleta != null)
                //        .OrderBy(x => x.Id).ToList();
                //var matriz = matrices.Last(x => x.NivelDeInconsistencia == NivelInconsistencia.Consistente);
                
                var evolucion =
                    new Evolucion(matriz, sesion);

                var experimento = evolucion.Evolucionar();
                experimento.MatrizOriginal = matriz;
                var distancia = experimento.DistanciaMatrices;

                var r1 = matriz.MatrizCompleta.CalcularRanking();
                var r2 = experimento.MatrizMejorada.CalcularRanking();

                //var desvio = r1.CalcularErrorRankings(r2);
                //var errorMax = matriz.MatrizCompleta.Dimension.CalcularErrorMaximo();


            }
        }

        private static void Evolucionar(int individuos)
        {
            int cantidad;
            int sesionId;

            using (var context = new GAContext())
            {
                cantidad = context.Matrices.Include("MatrizCompleta").Count(x => x.MatrizCompleta != null);

                var sesion = new SesionExperimentacion
                                 {
                                     ModeloEvolutivo = "ModeloEvolutivoEstandar",
                                     Individuos = individuos,

                                     Seleccion = "SelectorElitista",
                                     PorcentajeSeleccion = 0.1,

                                     Cruza = "SelectorRuleta>CruzadorSimple",
                                     PorcentajeCruza = 0,

                                     Mutacion = "SelectorUniforme>MutadorSimple",
                                     ProbabilidadMutacion = "ProbabilidadConvergencia",
                                     PorcentajeMinimoMutacion = 0.0,
                                     PorcentajeMaximoMutacion = 0.05,
                                     CrecimientoPorcentajeMutacion = 0.001,

                                     CondicionParada = "ParadaIteraciones:100&ParadaConsistencia:0.1",
                                     ConvergenciaPoblacion = "ConvergenciaEstructura",
                                     FuncionAptitud = "FuncionAptitudConsistenciaExponencial",
                                 };

                context.Sesiones.Add(sesion);
                context.SaveChanges();

                sesionId = sesion.Id;
            }

            //for (int i = 0; i < cantidad / 10; i++)
            for (int i = 0; i < cantidad; i+=1000)
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
                        .OrderByDescending(x => x.Id)
                        //.Skip(i*10).Take(10).ToList();
                        .Skip(i).Take(1000).ToList();
                    //Include("Experimentos").
                    var sesionExperimento = context.Sesiones.First(x => x.Id == sesionId);

                    if (sesionExperimento.Experimentos == null)
                        sesionExperimento.Experimentos = new List<ResultadoExperimento>();
                    
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
                    context.SaveChanges();
                }
                GC.Collect();
            }
        }

        private static void EvolucionarConsistentes(int individuos)
        {
            int sesionId;

            using (var context = new GAContext())
            {
                var sesion = new SesionExperimentacion
                {
                    ModeloEvolutivo = "ModeloEvolutivoEstandar",
                    Individuos = individuos,

                    Seleccion = "SelectorElitista",
                    PorcentajeSeleccion = 0.1,

                    Cruza = "SelectorRango>CruzadorSimple",
                    PorcentajeCruza = 0,

                    Mutacion = "SelectorUniforme>MutadorSimple",
                    ProbabilidadMutacion = "ProbabilidadConvergencia",
                    PorcentajeMinimoMutacion = 0.0,
                    PorcentajeMaximoMutacion = 0.05,
                    CrecimientoPorcentajeMutacion = 0.001,

                    CondicionParada = "ParadaIteraciones:500&ParadaConsistencia:",
                    ConvergenciaPoblacion = "ConvergenciaEstructura",
                    FuncionAptitud = "FuncionAptitudModificarValores",
                };

                context.Sesiones.Add(sesion);
                context.SaveChanges();

                sesionId = sesion.Id;
            }

            //for (int i = 0; i < cantidad / 10; i++)
            for (int i = 121; i < 250; i++)
            {
                using (var context = new GAContext())
                {
                    var matricesOriginales = context.ConjuntoMatrices
                        .Include("Matrices.Filas.Celdas")
                        .Include("Matrices.MatricesIncompletas.Filas.Celdas")
                        .Include("Matrices.Experimentos.MatrizMejorada.Filas.Celdas")
                        .First(x => x.Id == i)
                        .Matrices.ToList();

                    var sesionExperimento = context.Sesiones.First(x => x.Id == sesionId);

                    if (sesionExperimento.Experimentos == null)
                        sesionExperimento.Experimentos = new List<ResultadoExperimento>();
                    
                    var paradaOriginal = sesionExperimento.CondicionParada;

                    //var matriz = conjuntoIncompletas.First();
                    foreach (var matriz in matricesOriginales)
                    {
                        foreach (var matricesIncompleta in matriz.MatricesIncompletas)
                        {
                            sesionExperimento.CondicionParada +=
                                matricesIncompleta.MatrizCompleta.Inconsistencia.ToString();

                            var evolucion =
                                new Evolucion(matricesIncompleta,
                                              sesionExperimento);

                            var experimento =
                                evolucion.Evolucionar();

                            if (matricesIncompleta.Experimentos == null)
                                matricesIncompleta.Experimentos =
                                    new List<ResultadoExperimento>();
                            
                            matricesIncompleta.Experimentos.Add(experimento);
                            experimento.MatrizOriginal = matricesIncompleta;

                            experimento.MatrizMejorada.Error = experimento.MatrizMejorada.CalcularRanking().CalcularErrorRankings(matriz.CalcularRanking());
                            experimento.MatrizMejorada.ErrorRelativo = experimento.MatrizMejorada.Error/experimento.MatrizMejorada.Dimension.CalcularErrorMaximo();

                            //sesionExperimento.Experimentos.Add(experimento);
                            experimento.SesionExperimentacion = sesionExperimento;
                            GC.Collect();

                            sesionExperimento.CondicionParada = paradaOriginal;
                        }
                    }
                    context.SaveChanges();
                }
                GC.Collect();
            }
        }
    }
}
