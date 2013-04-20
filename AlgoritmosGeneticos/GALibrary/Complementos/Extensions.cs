using System;
using System.Linq;
using GALibrary.Persistencia;

namespace GALibrary.Complementos
{
    public static class Extensions
    {
        public static double Distancia(this double origen, double destino)
        {
            return Math.Pow((origen - destino), 2);
        }

        public static bool Entre(this double? valor, double cotaInferior, double cotaSuperior)
        {
            return (valor != null) && (cotaInferior <= valor) && (valor < cotaSuperior);
        }

        public static bool Entre(this double valor, double cotaInferior, double cotaSuperior)
        {
            return (cotaInferior <= valor) && (valor < cotaSuperior);
        }

        public static double PorcentajeCompleto(this double[] vector)
        {
            var longitud = vector.Length;
            var incompletos = vector.Count(x => x.Equals(CeldaMatriz.Incompleto));

            return (double)(longitud - incompletos)/longitud;
        }

        public static int CantidadValoresFaltantes(this double[] vector)
        {
            return vector.Count(x => x.Equals(CeldaMatriz.Incompleto));
        }

        public static double[] ValoresFaltantes(this double[] vector)
        {
            return (from c in vector
                    where c.Equals(CeldaMatriz.Incompleto)
                    select c).ToArray();
        }

        public static double[] ValoresCompletos(this double[] vector)
        {
            return (from c in vector
                    where !c.Equals(CeldaMatriz.Incompleto)
                    select c).ToArray();
        }
    }
}
