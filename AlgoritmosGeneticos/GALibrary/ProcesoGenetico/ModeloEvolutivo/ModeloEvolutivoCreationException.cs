using System;

namespace GALibrary.ProcesoGenetico.ModeloEvolutivo
{
    public class ModeloEvolutivoCreationException : ApplicationException
    {
        public ModeloEvolutivoCreationException(string msg)
            : base(msg)
        {}
    }
}
