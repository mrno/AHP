using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Complementos;
using GALibrary.ProcesoGenetico.Entidades;
using System.Globalization;

namespace GALibrary.ProcesoGenetico.CondicionParada
{
    [ElementoAG(TipoElementoAG.CondicionParada, "ParadaPorCRyError")]
    public class ParadaPorCRyError : ICondicionParada
    {
        #region Implementation of ICondicionParada

        private int _amortiguacion;
        private readonly double _maximoErrorTolerable;

        public ParadaPorCRyError(string maximoErrorTolerable)
        {
            _maximoErrorTolerable = double.Parse(maximoErrorTolerable, CultureInfo.InvariantCulture);
            _amortiguacion = 20;
        }

        //public bool Parar(Poblacion poblacion)
        //{
        //    if (poblacion.MejorIndividuo.Inconsistencia > 0.1) return false;

        //    var errorRelativo = poblacion.MejorIndividuo.ErrorRelativo;
        //    var errorAceptableEnIteracion = _maximoErrorTolerable/(poblacion.MaximaGeneracion - poblacion.Generacion + 1);
            
        //    if(errorRelativo > errorAceptableEnIteracion || poblacion.MejorIndividuo.Aptitud >= _mejorAptitud)
        //    {
        //        _amortiguacion = 20;
        //        return false;
        //    }

        //    if(_amortiguacion <= 0)
        //    {
        //        return true;
        //    }
        //    _amortiguacion--;
        //    return false;
        //}

        public bool Parar(Poblacion poblacion)
        {
            if (poblacion.MejorIndividuo.Inconsistencia > 0.1) return false;

            var errorRelativo = poblacion.MejorIndividuo.CambiosRelativos;
            var errorAceptableEnIteracion = _maximoErrorTolerable / (poblacion.MaximaGeneracion - poblacion.Generacion + 1);

            if (errorRelativo > errorAceptableEnIteracion)
            {
                _amortiguacion = 20;
                return false;
            }

            if (_amortiguacion <= 0)
            {
                return true;
            }
            _amortiguacion--;
            return false;
        }

        #endregion
    }
}
