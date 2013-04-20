using GALibrary.ProcesoGenetico.Entidades;
namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public interface IProbabilidadMutacion
    {
        double CalcularProbabilidad(Poblacion poblacion);
    }
}
