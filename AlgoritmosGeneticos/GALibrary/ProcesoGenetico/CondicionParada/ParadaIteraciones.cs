using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.CondicionParada
{
    public class ParadaIteraciones : ICondicionParada
    {
        private int _iteraciones;

        public ParadaIteraciones(string cantidad)
        {
            _iteraciones = int.Parse(cantidad);
        }

        public bool Parar(Poblacion poblacion)
        {
            return poblacion.Generacion >= _iteraciones;
        }
    }
}
