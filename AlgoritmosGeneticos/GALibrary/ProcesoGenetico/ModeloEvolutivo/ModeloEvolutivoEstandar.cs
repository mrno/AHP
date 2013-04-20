using System.Collections.Generic;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad;
using GALibrary.ProcesoGenetico.CondicionParada;

namespace GALibrary.ProcesoGenetico.ModeloEvolutivo
{
    public class ModeloEvolutivoEstandar : ModeloEvolutivoAbstracto
    {
        //public ModeloEvolutivoEstandar()
        //{
        //    //var config = ConfigurationManager.AppSettings[0];
        //    CrearOperador(x => Selector, new string[] {"SelectorElitista"});
        //    CrearOperador(x => Cruzador, new string[] {"SelectorRuleta", "CruzadorSimple"});
        //    CrearOperador(x => Mutador, new string[] {"SelectorUniforme", "MutadorSimple"});

        //    ProbabilidadMutacion =
        //        (new ProbabilidadMutacionFactory().CreateInstance("ProbabilidadConvergencia", new object[] { 0.0, 0.05 }));

        //    var parada = new ParadaCompuesta();
        //    parada.AgregarCondicion(new ParadaIteraciones(250));
        //    parada.AgregarCondicion(new ParadaConvergencia(0.95));

        //    CondicionParada = parada;
        //}
        
        public override Poblacion ObtenerSiguienteGeneracion(Poblacion poblacion)
        {
            //cantidades
            var cantidadIndividuos = poblacion.Individuos.Count;

            var individuosSeleccion = (int) (cantidadIndividuos*SesionExperimentacion.PorcentajeSeleccion);

            var individuosMutacion =
                (int) (cantidadIndividuos*ProbabilidadMutacion.CalcularProbabilidad(poblacion));

            var individuosCruza = cantidadIndividuos - individuosMutacion - individuosSeleccion;

            //crear poblacion siguiente vacia
            UltimaPoblacion = poblacion.Clone() as Poblacion;
            UltimaPoblacion.Generacion += 1;
            UltimaPoblacion.Individuos.Clear();
            
            //seleccionamos individuos
            if (individuosSeleccion > 0)
            {
                UltimaPoblacion.Individuos.AddRange(Selector.Operar(poblacion, individuosSeleccion));
            }
            //cruzamos individuos
            if (individuosCruza > 0)
            {
                UltimaPoblacion.Individuos.AddRange(Cruzador.Operar(poblacion, individuosCruza));
            }
            //mutamos individuos
            if (individuosMutacion > 0)
            {
                UltimaPoblacion.Individuos.AddRange(Mutador.Operar(poblacion, individuosMutacion));
            }
            return UltimaPoblacion;
        }
    }
}
