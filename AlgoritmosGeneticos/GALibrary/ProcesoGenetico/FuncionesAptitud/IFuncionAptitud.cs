using System;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.FuncionesAptitud
{
    public interface IFuncionAptitud : ICloneable
    {
        Estructura EstructuraBase { get; set; }
        Estructura EstructuraObjetivo { get; set; }

        double Aptitud(Individuo individuo);
        double AptitudObjetivo { get; }
    }
}
