using System;

namespace GALibrary.ProcesoGenetico.Selectores
{
    public class SelectorCreationException : ApplicationException
    {
        public SelectorCreationException(string msg) : base(msg) {}
    }
}
