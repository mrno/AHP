using System.Collections.Generic;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.Complementos;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores
{
    public class MutadorSimple : MutadorAbstracto
    {
        public override IEnumerable<Individuo> Operar(Poblacion poblacion, int numeroMutados)
        {
            var resultado = new List<Individuo>();

            var individuos = poblacion.Individuos;
            var cantidadCaracteristicas = individuos[0].Estructura.Length;

            for (int i = 0; i < numeroMutados; i++)
            {
                var mutaciones = Random.Next(0, cantidadCaracteristicas);
                var individuo = individuos[i].Clone() as Individuo;
                individuo.GeneracionNacimiento = poblacion.Generacion;

                for (int j = 0; j < mutaciones; j++)
                {
                    var posicion = Random.Next(0, cantidadCaracteristicas);
                    individuo.Estructura[posicion] = Utilidades.ValorAleatorioEscalaFundamental();
                }

                individuo.ActualizarAptitud();

                resultado.Add(individuo);
            }

            return resultado;
        }
    }
}
