using GALibrary.ProcesoGenetico.Entidades;
namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadTemperaturaDescendente : IProbabilidadMutacion
    {
        private double _probabilidadMenor;
        private double _probabilidadMayor;
        private double _pendiente;
        
        public double CalcularProbabilidad(Poblacion poblacion)
        {
            var resultado = _probabilidadMayor - _pendiente * poblacion.Generacion;
            return resultado < _probabilidadMenor ? _probabilidadMenor : resultado;
        }

        public void AsignarPorcentajes(double probabilidadMenor, double probabilidadMayor, double pendiente)
        {
            _probabilidadMenor = probabilidadMenor;
            _probabilidadMayor = probabilidadMayor;
            _pendiente = pendiente;
        }
    }
}
