using System.Linq.Expressions;
using GALibrary.ProcesoGenetico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Operadores;
using GALibrary.ProcesoGenetico.Operadores.Abstracto;
using GALibrary.ProcesoGenetico.Operadores.Cruzadores;
using GALibrary.ProcesoGenetico.Operadores.Selectores;
using GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad;
using GALibrary.ProcesoGenetico.CondicionParada;
using GALibrary.Persistencia;
using GALibrary.Complementos;

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

        public void RegistrarInicioExperimento()
        {
            Experimento = new ResultadoExperimento
                              {
                                  Inicio = DateTime.Now,
                                  Fin = DateTime.Now
                              };
        }

        public void RegistrarFinExperimento()
        {
            Experimento.Fin = DateTime.Now;

            var matriz = UltimaPoblacion.MejorIndividuo.Matriz;
            Experimento.MatrizMejorada = new ObjetoMatriz(matriz.GetLength(0), false, false, 0)
                                             {
                                                 Matriz = matriz,
                                                 Completa = true,
                                                 Inconsistencia = UltimaPoblacion.MejorIndividuo.Inconsistencia
                                             };
           
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
