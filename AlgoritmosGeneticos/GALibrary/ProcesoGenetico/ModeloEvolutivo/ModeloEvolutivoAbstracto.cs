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

namespace GALibrary.ProcesoGenetico.ModeloEvolutivo
{
    public abstract class ModeloEvolutivoAbstracto : IModeloEvolutivo
    {
        protected Poblacion UltimaPoblacion;
        protected ICondicionParada CondicionParada { get; set; }

        public IOperador Selector { get; set; }
        public IOperador Cruzador { get; set; }
        public IOperador Mutador { get; set; }

        protected IProbabilidadMutacion ProbabilidadMutacion { get; set; }
        
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
        public abstract bool Parada { get; }
    }
}
