namespace GALibrary.ProcesoGenetico.Mutadores.Probabilidad
{
    public class ProbabilidadConstante : IMutadorProbabilidad
    {
        private double _probabilidad;
        public ProbabilidadConstante(double probabilidad)
        {
            _probabilidad = probabilidad;
        }

        public double CalcularProbabilidad(int generacion)
        {
            return _probabilidad;
        }
    }
}
