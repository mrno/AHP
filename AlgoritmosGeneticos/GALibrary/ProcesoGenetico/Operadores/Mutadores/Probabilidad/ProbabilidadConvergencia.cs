using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadConvergencia : IProbabilidadMutacion
    {
        protected double ProbabilidadMayor;
        protected double ProbabilidadMenor;

        public ProbabilidadConvergencia(double probabilidadMenor, double probabilidadMayor)
        {
            ProbabilidadMayor = probabilidadMayor;
            ProbabilidadMenor = probabilidadMenor;
        }

        public double CalcularProbabilidad(Poblacion poblacion)
        {
            return (ProbabilidadMayor - ProbabilidadMenor) * poblacion.Convergencia + ProbabilidadMenor;
        }
    }
}
