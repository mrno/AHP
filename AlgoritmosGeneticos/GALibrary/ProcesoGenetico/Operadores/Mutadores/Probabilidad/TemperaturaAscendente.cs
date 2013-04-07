namespace GALibrary.ProcesoGenetico.Mutadores.Probabilidad
{
    public class TemperaturaAscendente : IMutadorProbabilidad
    {
        private double _probabilidadMenor;
        private double _probabilidadMayor;
        private double _pendiente;
        public TemperaturaAscendente(double ProbabilidadMenor, double ProbabilidadMayor, double Pendiente)
        {
            _probabilidadMenor = ProbabilidadMenor;
            _probabilidadMayor = ProbabilidadMayor;
            _pendiente = Pendiente;
        }
        public double CalcularProbabilidad(int generacion)
        {
            double resultado = _probabilidadMayor + _pendiente * generacion;
            if (resultado > _probabilidadMayor) return _probabilidadMayor;
            return resultado;
        }
    }
}
