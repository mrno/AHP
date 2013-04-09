using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad;
using GALibrary.ProcesoGenetico.CondicionParada;

namespace GALibrary.ProcesoGenetico.ModeloEvolutivo
{
    public class ModeloEvolutivoEstandar : ModeloEvolutivoAbstracto
    {
        public ModeloEvolutivoEstandar()
        {
            //var config = ConfigurationManager.AppSettings[0];
            CrearOperador(x => Selector, new string[] {"SelectorElitista"});
            CrearOperador(x => Cruzador, new string[] {"SelectorRuleta", "CruzadorSimple"});
            CrearOperador(x => Mutador, new string[] {"SelectorUniforme", "MutadorSimple"});

            ProbabilidadMutacion =
                (new ProbabilidadMutacionFactory().CreateInstance("ProbabilidadConvergencia", new object[] { 0.1, 0.25 }));

            var parada = new ParadaCompuesta();
            parada.AgregarCondicion(new ParadaIteraciones(100));
            parada.AgregarCondicion(new ParadaConvergencia(0.9));

            CondicionParada = parada;
        }

        public override Poblacion ObtenerSiguienteGeneracion(Poblacion poblacion)
        {
            //cantidades
            var cantidadIndividuos = poblacion.Individuos.Count;

            var individuosSeleccion = (int) (cantidadIndividuos*0.1);

            var individuosMutacion =
                (int) (cantidadIndividuos*ProbabilidadMutacion.CalcularProbabilidad(poblacion));

            var individuosCruza = cantidadIndividuos - individuosMutacion - individuosSeleccion;

            //crear poblacion siguiente vacia
            UltimaPoblacion = new Poblacion(poblacion.Generacion + 1);
            
            //seleccionamos individuos
            UltimaPoblacion.Individuos.AddRange(Selector.Operar(poblacion, individuosSeleccion));

            //cruzamos individuos
            UltimaPoblacion.Individuos.AddRange(Cruzador.Operar(poblacion, individuosCruza));

            //mutamos individuos
            UltimaPoblacion.Individuos.AddRange(Mutador.Operar(poblacion, individuosMutacion));

            return UltimaPoblacion;
        }

        public override bool Parada
        {
            get { return CondicionParada.Parar(UltimaPoblacion); }
        }
    }
}
