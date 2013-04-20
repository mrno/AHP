﻿using GALibrary.ProcesoGenetico.Entidades;
namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadTemperaturaAscendente : IProbabilidadMutacion
    {
        private double _probabilidadMenor;
        private double _probabilidadMayor;
        private double _pendiente;

        public double CalcularProbabilidad(Poblacion poblacion)
        {
            var resultado = _probabilidadMenor + _pendiente * poblacion.Generacion;
            return resultado > _probabilidadMayor ? _probabilidadMayor : resultado;
        }
        
        public void AsignarPorcentajes(double probabilidadMenor, double probabilidadMayor, double pendiente)
        {
            _probabilidadMenor = probabilidadMenor;
            _probabilidadMayor = probabilidadMayor;
            _pendiente = pendiente;
        }
    }
}
