using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.Complementos
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ElementoAG : Attribute
    {
        private readonly TipoElementoAG _elementoAG;
        private readonly string _nombre;

        /// <summary>
        /// Este método atributo espeficica el tipo de elemento del proceso genético que se está definiendo y el nombre que se muestra.
        /// </summary>
        /// <param name="elementoAG">Operadores, condiciones de parada, etc.</param>
        /// <param name="nombre">Nombre a mostrar</param>
        public ElementoAG(TipoElementoAG elementoAG, string nombre)
        {
            _elementoAG = elementoAG;
            _nombre = nombre;
        }

        public TipoElementoAG TipoElementoAG
        {
            get { return _elementoAG; }
        }
        
        public string Nombre
        {
            get { return _nombre; }
        }
    }

    public enum TipoElementoAG
    {
        CondicionParada,
        ConvergenciaPoblacion,
        FuncionAptitud,
        ModeloEvolutivo,
        Operador,
        ProbabilidadMutacion
    }
}
