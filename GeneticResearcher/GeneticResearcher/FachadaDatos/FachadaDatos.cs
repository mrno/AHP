using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.FachadaDatos
{
    public static class FachadaDatos
    {
        public static IEnumerable<int> ObtenerConjuntoDimensiones()
        {
            return new List<int> {4, 5, 6, 7, 8, 9};
        }

        public static IEnumerable<string> ObtenerNivelesInconsistencia()
        {
            return new List<string> {"Bajo", "Medio", "Alto", "Muy Alto"};
        }

        public static IEnumerable<int> ConjuntosDisponibles(int dimension, string nivelInconsistencia)
        {
            var lista = new List<int>();
            for (int i = 0; i < dimension; i++)
            {
                lista.Add(nivelInconsistencia.Length + i);
            }
            return lista;
        }

        public static IEnumerable<int> ObtenerConjuntosPersonalizados()
        {
            var lista = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                lista.Add(5+i);
            }
            return lista;
        }
    }
}
