using System;

namespace GALibrary.ProcesoGenetico.Operadores.Abstracto
{
    public class OperadorCreationException : ApplicationException
    {
        public OperadorCreationException(string msg)
            : base(msg)
        {}
    }
}
