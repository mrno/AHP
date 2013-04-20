using GALibrary.ProcesoGenetico.Entidades;
using System;
using System.Collections.Generic;

namespace GALibrary.ProcesoGenetico.Operadores.Abstracto
{
    public abstract class OperadorAbstractoSimple : IOperador
    {
        public static Random Random = new Random();

        public abstract IEnumerable<Individuo> Operar(Poblacion poblacion, int cantidadIndividuos);
    }
}
