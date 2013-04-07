using System;

namespace GALibrary.ProcesoGenetico.Mutadores
{
    public class MutadorCreationException : ApplicationException
    {
        public MutadorCreationException(string msg)
            : base(msg)
        {}
    }
}
