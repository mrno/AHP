using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Complementos;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Cruzadores
{
    [ElementoAG(TipoElementoAG.Operador, "CruzadorSimple")]
    public class CruzadorTransitivoDeTres : CruzadorAbstracto
    {
        #region Overrides of OperadorAbstractoSimple

        public override IEnumerable<Individuo> Operar(Poblacion poblacion, int cantidadHijos)
        {
            var resultado = new List<Individuo>();
            var total = poblacion.Individuos.Count;

            for (var i = 0; i < cantidadHijos; i += 2)
            {
                var padre = poblacion.Individuos.ElementAt(i % total);
                var madre = poblacion.Individuos.ElementAt((i + 1) % total);

                resultado.AddRange(ObtenerHijos(padre, madre, poblacion.Generacion).ToList());
            }
            var hijos = resultado.Take(cantidadHijos).ToList();

            foreach (var hijo in hijos)
            {
                hijo.ActualizarInconsistenciaAptitud();
            }
            return hijos;
        }

        private IEnumerable<Individuo> ObtenerHijos(Individuo padre, Individuo madre, int generacion)
        {
            var hijo1 = padre.Clone() as Individuo;
            var hijo2 = madre.Clone() as Individuo;

            hijo1.GeneracionNacimiento = generacion;
            hijo2.GeneracionNacimiento = generacion;

            var cantidadCaracteristicas = padre.Estructura.Length;

            var matriz1 = Utilidades.ConvertirVectorEnMatriz(hijo1.Estructura);
            var matriz2 = Utilidades.ConvertirVectorEnMatriz(hijo2.Estructura);

            var dimension = matriz1.GetLength(0);

            var inicio = Random.Next(0, dimension);
            for (int i = 0; i < cantidadCaracteristicas/2; i++)
            {
                var siguiente = inicio;
                while (inicio == siguiente)
                {
                    siguiente = Random.Next(0, dimension);
                }

                var temporal = matriz1[inicio, siguiente];
                matriz1[inicio, siguiente] = matriz2[inicio, siguiente];
                matriz2[inicio, siguiente] = temporal;

                temporal = matriz1[siguiente, inicio];
                matriz1[siguiente, inicio] = matriz2[siguiente, inicio];
                matriz2[siguiente, inicio] = temporal;

                inicio = siguiente;
            }

            hijo1.Estructura = Utilidades.ConvertirMatrizEnVector(matriz1);
            hijo2.Estructura = Utilidades.ConvertirMatrizEnVector(matriz2);

            return new List<Individuo> { hijo1, hijo2 };
        }

        #endregion
    }
}
