namespace GALibrary.ProcesoGenetico.Mutadores.Probabilidad
{
    public class TemperaturaDescendente : IMutadorProbabilidad
    {
        private double _probabilidadMenor;
        private double _probabilidadMayor;
        private double _pendiente;
        public TemperaturaDescendente(double ProbabilidadMenor, double ProbabilidadMayor, double Pendiente)
        {
            _probabilidadMenor = ProbabilidadMenor;
            _probabilidadMayor = ProbabilidadMayor;
            _pendiente = Pendiente;
        }
        public double CalcularProbabilidad(int generacion)
        {
            double resultado = _probabilidadMayor - _pendiente * generacion;
            if (resultado < _probabilidadMenor) return _probabilidadMenor;
            return resultado;
        }
    }
}
