using GALibrary.ProcesoGenetico.Entidades;
namespace GALibrary.ProcesoGenetico.CondicionParada
{
    public interface ICondicionParada
    {
        bool Parar(Poblacion poblacion);
    }
}
