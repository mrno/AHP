using System;

namespace GALibrary.ProcesoGenetico.Cruzadores
{
    public class CruzadorCreationException : ApplicationException
    {
        public CruzadorCreationException(string msg)
            : base(msg)
        {}
    }
}
