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
        protected SesionExperimentacion SesionExperimentacion { get; set; }

        public IOperador Selector { get; set; }
        public IOperador Cruzador { get; set; }
        public IOperador Mutador { get; set; }

        public void ConfigurarModelo(SesionExperimentacion sesion)
        {
            SesionExperimentacion = sesion;

            CrearOperador(x => Selector, sesion.Seleccion.Split('>'));
            CrearOperador(x => Cruzador, sesion.Cruza.Split('>'));
            CrearOperador(x => Mutador, sesion.Mutacion.Split('>'));

            ProbabilidadMutacion =
                (new ProbabilidadMutacionFactory().CreateInstance(sesion.ProbabilidadMutacion));
            ProbabilidadMutacion.AsignarPorcentajes(sesion.PorcentajeMinimoMutacion, sesion.PorcentajeMaximoMutacion,
                                                    sesion.CrecimientoPorcentajeMutacion);

            CondicionParada = new ParadaCompuesta();
            var factoryParada = new CondicionParadaFactory();

            var condiciones = sesion.CondicionParada.Split('&');
            foreach (var c in condiciones)
            {
                var condicion = c.Split(':');
                CondicionParada.AgregarCondicion(factoryParada.CreateInstance(condicion[0], new object[] { condicion[1] }));
            }
        }

        protected IProbabilidadMutacion ProbabilidadMutacion { get; set; }

        protected ResultadoExperimento Experimento;

        public void RegistrarInicioExperimento(Poblacion poblacionInicial)
        {
            UltimaPoblacion = poblacionInicial;
            Experimento = new ResultadoExperimento
                              {
                                  Inicio = DateTime.Now,
                                  Fin = DateTime.Now,
                                  AptitudInicialMejorIndividuo = poblacionInicial.MejorIndividuo.Aptitud,
                                  AptitudPromedioInicialPoblacion = poblacionInicial.AptitudMedia,
                                  SesionExperimentacion = SesionExperimentacion
                              };
        }

        public void RegistrarFinExperimento()
        {
            Experimento.Fin = DateTime.Now;
            Experimento.Duracion = Experimento.Fin.Subtract(Experimento.Inicio);

            Experimento.AptitudFinalMejorIndividuo = UltimaPoblacion.MejorIndividuo.Aptitud;
            Experimento.AptitudPromedioFinalPoblacion = UltimaPoblacion.AptitudMedia;

            Experimento.MatrizMejorada = new ObjetoMatriz(UltimaPoblacion.MejorIndividuo.Matriz.GetLength(0),
                                                          false, false, 0)
                                             {
                                                 Matriz = UltimaPoblacion.MejorIndividuo.Matriz,
                                                 Completa = true,
                                                 Completitud = 1,
                                                 Inconsistencia = UltimaPoblacion.MejorIndividuo.Inconsistencia,
                                                 Error = UltimaPoblacion.MejorIndividuo.Cambios
                                             };

            Experimento.Cambios = UltimaPoblacion.MejorIndividuo.Cambios;
            Experimento.IteracionesRealizadas = UltimaPoblacion.Generacion;
            Experimento.IteracionNacimientoMejor = UltimaPoblacion.MejorIndividuo.GeneracionNacimiento;
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

        public ResultadoExperimento ExperimentoResultado
        { 
            get { return Experimento; }
        }
    }
}
