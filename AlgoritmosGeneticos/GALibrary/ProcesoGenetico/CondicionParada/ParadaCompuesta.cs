using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.CondicionParada
{
    public class ParadaCompuesta : ICondicionParada
    {
        private List<ICondicionParada> _subCondiciones;

        public ParadaCompuesta()
        {
            _subCondiciones = new List<ICondicionParada>();
        }

        public void AgregarCondicion(ICondicionParada condicion)
        {
            _subCondiciones.Add(condicion);
        }
        
        public bool Parar(Poblacion poblacion)
        {
            return _subCondiciones.Any(x => x.Parar(poblacion));
        }
    }
}
