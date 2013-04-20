using GALibrary.ProcesoGenetico.Entidades;
namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadTemperaturaAscendente : IProbabilidadMutacion
    {
        private readonly double _probabilidadMenor;
        private readonly double _probabilidadMayor;
        private readonly double _pendiente;

        public ProbabilidadTemperaturaAscendente(double probabilidadMenor, double probabilidadMayor, double pendiente)
        {
            _probabilidadMenor = probabilidadMenor;
            _probabilidadMayor = probabilidadMayor;
            _pendiente = pendiente;
        }
        public double CalcularProbabilidad(Poblacion poblacion)
        {
            var resultado = _probabilidadMenor + _pendiente * poblacion.Generacion;
            return resultado > _probabilidadMayor ? _probabilidadMayor : resultado;
        }
    }
}
