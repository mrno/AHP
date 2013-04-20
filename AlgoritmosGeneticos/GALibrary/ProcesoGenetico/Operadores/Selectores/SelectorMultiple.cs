using System.Collections.Generic;
using System.Linq;
using GALibrary.ProcesoGenetico.Entidades;

namespace GALibrary.ProcesoGenetico.Operadores.Selectores
{
    public class SelectorMultiple : SelectorAbstracto
    {
        int[] _cantidades;
        int _nroSeleccionadores;
        List<SelectorAbstracto> _seleccionadores = new List<SelectorAbstracto>();
        SelectorFactory _seleccionFactory = new SelectorFactory();

        public SelectorMultiple(string[] args)
        {
            _nroSeleccionadores = args.Length;
            _cantidades = new int[_nroSeleccionadores];
            foreach (var item in args)
            {
                _seleccionadores.Add(_seleccionFactory.CreateInstance(item));
            }
        }

        public override IEnumerable<Individuo> Operar(Poblacion poblacion, int nroSeleccionados)
        {
            int seleccionadosRestantes = nroSeleccionados;
            int reparticion = (int)(seleccionadosRestantes / _nroSeleccionadores);
            for (int i = 0; i < (_nroSeleccionadores - 1); i++)
            {
                _cantidades[i] = reparticion;
                seleccionadosRestantes -= reparticion;
            }
            _cantidades[_nroSeleccionadores - 1] = seleccionadosRestantes;

            List<Individuo> resultado = new List<Individuo>();
            for (int i = 0; i < _nroSeleccionadores; i++)
            {
                resultado.AddRange(_seleccionadores.ElementAt(i).Operar(poblacion, _cantidades[i]));
            }
            return resultado;
        }
    }
}
