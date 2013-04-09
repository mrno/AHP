using GALibrary.ProcesoGenetico.Operadores.Abstracto;
using GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores
{
    public abstract class MutadorAbstracto : OperadorAbstractoSimple
    {
        public IProbabilidadMutacion Probabilidad;
        //public abstract IEnumerable<Individuo> Mutar(IEnumerable<Individuo> individuos ,int nroMutados);
    }
}
