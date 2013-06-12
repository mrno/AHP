using System;
using System.Linq;
using System.Collections.Generic;
using GALibrary.Complementos;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Cruzadores
{
    [ElementoAG(TipoElementoAG.Operador, "CruzadorSimple")]
    public class CruzadorSimple : CruzadorAbstracto
    {
        public override IEnumerable<Individuo> Operar(Poblacion poblacion, int cantidadHijos)
        {
            var resultado = new List<Individuo>();
            var total = poblacion.Individuos.Count;

            for (var i = 0; i < cantidadHijos; i+= 2)
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
            var hijo2 = padre.Clone() as Individuo;

            hijo1.GeneracionNacimiento = generacion;
            hijo2.GeneracionNacimiento = generacion;

            var cantidadCaracteristicas = padre.Estructura.Length;

            var corte = Random.Next(1, cantidadCaracteristicas);

            for (var i = 0; i < corte; i++)
            {
                hijo1.Estructura[i] = madre.Estructura[i];
            }

            for (var i = corte; i < cantidadCaracteristicas; i++)
            {
                hijo2.Estructura[i] = madre.Estructura[i];
            }
            
            return new List<Individuo>() {hijo1, hijo2};
        }
    }
}
