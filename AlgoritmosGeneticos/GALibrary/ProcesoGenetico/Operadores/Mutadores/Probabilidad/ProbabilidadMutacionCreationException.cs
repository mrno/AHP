using System;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadMutacionException : ApplicationException
    {
        public ProbabilidadMutacionException(string msg)
            : base(msg)
        {}
    }
}
