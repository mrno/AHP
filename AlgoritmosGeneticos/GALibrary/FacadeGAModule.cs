using GALibrary.Complementos;
using GALibrary.Persistencia;
using GALibrary.ProcesoGenetico.Operadores.Abstracto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary
{
    public static class FacadeGAModule
    {
        /// <summary>
        /// Obtiene los tipos de elementos del proceso de AG cuyo atributo especifica el tipo seleccionado.
        /// </summary>
        /// <param name="tipoElementoAG"></param>
        /// <returns></returns>
        public static IEnumerable<string> ObtenerElementosAG(TipoElementoAG tipoElementoAG)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.GetCustomAttributes(typeof (ElementoAG), true).Any()).ToList();

            var nombres = new List<string>();

            foreach (var type in types)
            {
                nombres.AddRange(from c in type.GetCustomAttributes(typeof (ElementoAG), true)
                                 let elementoAG = c as ElementoAG
                                 where elementoAG != null && elementoAG.TipoElementoAG == tipoElementoAG
                                 select elementoAG.Nombre);
            }
            return nombres;
        }

        public static IEnumerable<int> ObtenerDimensiones()
        {
            using (var context = new GAContext())
            {
                return (from c in context.ConjuntosOrdenN
                        select c.Dimension).Distinct().ToList();
            }
        }

        public static IEnumerable<NivelInconsistencia> ObtenerNivelesInconsistencia()
        {
            using (var context = new GAContext())
            {
                return (from c in context.ConjuntoMatrices
                        select c.NivelInconsistencia).Distinct().ToList();
            }
        }

        public static IEnumerable<ConjuntoMatriz> ObtenerTodosLosConjuntosYSubconjuntos()
        {
            using (var context = new GAContext())
            {
                return (from c in context.ConjuntoMatrices.Include("ConjuntoOrdenN")
                       select c).ToList();
            }
        }
    }
}
