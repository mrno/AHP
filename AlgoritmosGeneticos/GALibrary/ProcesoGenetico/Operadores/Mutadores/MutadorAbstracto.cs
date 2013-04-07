using GALibrary.ProcesoGenetico.Mutadores.Probabilidad;
using GALibrary.ProcesoGenetico.Operadores.Abstracto;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores
{
    public abstract class MutadorAbstracto : OperadorAbstractoSimple
    {
        public IMutadorProbabilidad Probabilidad;
        //public abstract IEnumerable<Individuo> Mutar(IEnumerable<Individuo> individuos ,int nroMutados);
    }
}
