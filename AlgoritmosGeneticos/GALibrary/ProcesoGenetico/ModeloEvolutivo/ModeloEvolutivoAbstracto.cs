using System.Linq.Expressions;
using GALibrary.ProcesoGenetico.Entidades;
using System;
using System.Collections.Generic;
using GALibrary.ProcesoGenetico.Operadores.Abstracto;
using GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad;
using GALibrary.ProcesoGenetico.CondicionParada;
using GALibrary.Persistencia;

namespace GALibrary.ProcesoGenetico.ModeloEvolutivo
{
    public abstract class ModeloEvolutivoAbstracto : IModeloEvolutivo
    {
        protected Poblacion UltimaPoblacion;
        protected ParadaCompuesta CondicionParada { get; set; }
        protected ParametrosEjecucionAG SesionExperimentacion { get; set; }

        public IOperador Selector { get; set; }
        public IOperador Cruzador { get; set; }
        public IOperador Mutador { get; set; }

        public void ConfigurarModelo(ParametrosEjecucionAG parametros)
        {
            SesionExperimentacion = parametros;

            CrearOperador(x => Selector, parametros.OperadoresSeleccion.Split('>'));
            CrearOperador(x => Cruzador, parametros.OperadoresCruza.Split('>'));
            CrearOperador(x => Mutador, parametros.OperadoresMutacion.Split('>'));

            ProbabilidadMutacion =
                (new ProbabilidadMutacionFactory().CreateInstance(parametros.ProbabilidadMutacion));
            ProbabilidadMutacion.AsignarPorcentajes(parametros.PorcentajeMinimoMutacion, parametros.PorcentajeMaximoMutacion,
                                                    parametros.CrecimientoPorcentajeMutacion);

            CondicionParada = new ParadaCompuesta();
            var factoryParada = new CondicionParadaFactory();

            var condiciones = parametros.CondicionParada.Split('&');
            foreach (var c in condiciones)
            {
                var condicion = c.Split(':');
                CondicionParada.AgregarCondicion(factoryParada.CreateInstance(condicion[0], new object[] { condicion[1] }));
            }
        }

        protected IProbabilidadMutacion ProbabilidadMutacion { get; set; }

        public Correccion Correccion { get; private set; }

        public void RegistrarInicioExperimento(Poblacion poblacionInicial, ObjetoMatriz matrizOriginal)
        {
            UltimaPoblacion = poblacionInicial;
            Correccion = new CorreccionAG
                             {
                                 MatrizOriginal = matrizOriginal,
                                 ValoresSalidaEjecucion = new ValoresSalidaEjecucionAG()
                                                              {
                                                                  Inicio = DateTime.Now,
                                                                  Fin = DateTime.Now,
                                                                  AptitudInicialMejorIndividuo =
                                                                      poblacionInicial.MejorIndividuo.Aptitud,
                                                                  AptitudPromedioInicialPoblacion =
                                                                      poblacionInicial.AptitudMedia
                                                              }
                             };
        }

        public void RegistrarFinExperimento()
        {
            var valoresSalida = Correccion.ValoresSalidaEjecucion as ValoresSalidaEjecucionAG;
            Correccion.ValoresSalidaEjecucion.Fin = DateTime.Now;

            valoresSalida.AptitudFinalMejorIndividuo = UltimaPoblacion.MejorIndividuo.Aptitud;
            valoresSalida.AptitudPromedioFinalPoblacion = UltimaPoblacion.AptitudMedia;

            Correccion.MatrizCorregida = new ObjetoMatriz(UltimaPoblacion.MejorIndividuo.Matriz.GetLength(0),
                                                          false, false, 0)
                                             {
                                                 Matriz = UltimaPoblacion.MejorIndividuo.Matriz,
                                                 Completa = true,
                                                 Completitud = 1,
                                                 Inconsistencia = UltimaPoblacion.MejorIndividuo.Inconsistencia,
                                                 Error = UltimaPoblacion.MejorIndividuo.Cambios
                                             };

            valoresSalida.Cambios = UltimaPoblacion.MejorIndividuo.Cambios;
            valoresSalida.IteracionesRealizadas = UltimaPoblacion.Generacion;
            valoresSalida.IteracionNacimientoMejor = UltimaPoblacion.MejorIndividuo.GeneracionNacimiento;
        }

        /// <summary>
        /// Permite crear un operador, o una serie de operados aplicados sucesivamente.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="operadores">Indica la lista de operadores simples aplicados en serie.</param>
        public void CrearOperador(Expression<Func<ModeloEvolutivoAbstracto, IOperador>> property, string[] operadores)
        {
            if (operadores != null && operadores.Length > 0)
            {
                var factory = new OperadorFactory();

                var subOperadores = new List<OperadorAbstractoSimple>();
                for (int i = 0; i < operadores.Length; i++)
                {
                    var subOperador = factory.CreateInstance(operadores[i]) as OperadorAbstractoSimple;
                    if (subOperador != null)
                    {
                        subOperadores.Add(subOperador);
                    }
                }
                var operador = new OperadorSerie {Operadores = subOperadores};
                
                var memberExpression = property.Body as MemberExpression;
                //var propiedad = (IOperador)GetType().GetProperty(memberExpression.Member.Name).GetValue(this, null);
                GetType().GetProperty(memberExpression.Member.Name).SetValue(this, operador, null);
            }
        }

        public abstract Poblacion ObtenerSiguienteGeneracion(Poblacion poblacion);

        public bool Parada
        {
            get { return CondicionParada != null && CondicionParada.Parar(UltimaPoblacion); }
        }
    }
}
