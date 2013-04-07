using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Abstracto
{
    public abstract class OperadorAbstractoMultiple : IOperador
    {
        
        public abstract IEnumerable<Individuo> Operar(Poblacion poblacion, int cantidadIndividuos);

        //public OperadorAbstractoMultiple CrearSubOperador(string operadores)
        //{
        //    var factory = new OperadorFactory();
        //    IOperador operador = factory.CreateInstance(operadores);
        //    Operadores.Add(operador);
        //    return operador as OperadorAbstractoMultiple;
        //}
    }
}
