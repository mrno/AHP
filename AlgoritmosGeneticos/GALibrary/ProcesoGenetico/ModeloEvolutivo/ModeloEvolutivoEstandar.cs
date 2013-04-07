using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Mutadores;
using GALibrary.ProcesoGenetico.Entidades;
using GALibrary.ProcesoGenetico.Operadores.Abstracto;

namespace GALibrary.ProcesoGenetico.ModeloEvolutivo
{
    public class ModeloEvolutivoEstandar : ModeloEvolutivoAbstracto
    {
        public ModeloEvolutivoEstandar()
        {
            CrearOperador(x => Selector, new string[] {"SelectorElitista"});
            CrearOperador(x => Cruzador, new string[] {"SelectorRuleta", "CruzadorSimple"});
            CrearOperador(x => Mutador, new string[] {"SelectorUniforme", "MutadorSimple"});
        }

        public override Poblacion ObtenerSiguienteGeneracion(Poblacion poblacion)
        {
            //calcular aptitud
            //poblacion.ActualizarAptitudIndividuos();

            //crear poblacion siguiente vacia
            var nuevaPoblacion = new Poblacion(poblacion.Generacion + 1);
            
            //seleccionamos individuos
            nuevaPoblacion.Individuos.AddRange(Selector.Operar(poblacion, 20));

            //cruzamos individuos
            nuevaPoblacion.Individuos.AddRange(Cruzador.Operar(poblacion, 60));

            //mutamos individuos
            nuevaPoblacion.Individuos.AddRange(Mutador.Operar(poblacion, 20));

            return nuevaPoblacion;
        }

        public override bool Parada
        {
            get { throw new NotImplementedException(); }
        }
    }
}
