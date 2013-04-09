using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadConstante : IProbabilidadMutacion
    {
        private readonly double _probabilidad;
        public ProbabilidadConstante(double probabilidad)
        {
            _probabilidad = probabilidad;
        }

        public double CalcularProbabilidad(Poblacion poblacion)
        {
            return _probabilidad;
        }
    }
}
