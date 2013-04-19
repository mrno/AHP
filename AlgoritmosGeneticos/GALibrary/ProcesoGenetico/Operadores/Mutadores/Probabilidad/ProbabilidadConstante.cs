using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadConstante : IProbabilidadMutacion
    {
        private double _probabilidad;
 
        public double CalcularProbabilidad(Poblacion poblacion)
        {
            return _probabilidad;
        }
        
        public void AsignarPorcentajes(double probabilidadMenor, double probabilidadMayor, double crecimiento)
        {
            _probabilidad = probabilidadMenor;
        }
    }
}
