using GALibrary.ProcesoGenetico.Entidades;
namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public interface IProbabilidadMutacion
    {
        void AsignarPorcentajes(double probabilidadMenor, double probabilidadMayor, double crecimiento);
        double CalcularProbabilidad(Poblacion poblacion);
    }
}
