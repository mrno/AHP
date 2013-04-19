using System;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.FuncionesAptitud
{
    public interface IFuncionAptitud
    {
        Estructura EstructuraBase { get; set; }
        double Aptitud(Individuo individuo);
    }
}
