using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadConvergencia : IProbabilidadMutacion
    {
        protected double ProbabilidadMayor;
        protected double ProbabilidadMenor;
        
        public double CalcularProbabilidad(Poblacion poblacion)
        {
            return (ProbabilidadMayor - ProbabilidadMenor) * poblacion.Convergencia + ProbabilidadMenor;
        }
        
        public void AsignarPorcentajes(double probabilidadMenor, double probabilidadMayor, double crecimiento)
        {
            ProbabilidadMayor = probabilidadMayor;
            ProbabilidadMenor = probabilidadMenor;
        }
    }
}
