﻿using GALibrary.Complementos;
using GALibrary.ProcesoGenetico.FuncionesAptitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALibrary.ProcesoGenetico.Entidades
{
    public class Individuo : ICloneable
    {
        public double[] Estructura { get; set; }
        private double? _aptitud;
        private double? _inconsistencia;
        public int GeneracionNacimiento { get; set; }

        private IFuncionAptitud _funcionAptitud;

        public double Aptitud
        {
            get
            {
                if(_aptitud == null)
                {
                    ActualizarInconsistenciaAptitud();
                }
                return (double)_aptitud; 
            }
        }

        public void ActualizarInconsistenciaAptitud()
        {
            _inconsistencia = Utilidades.CalcularConsistencia(Matriz);
            _aptitud = _funcionAptitud.Aptitud(this);
        }

        public double[] Vector
        {
            get { return Utilidades.CombinarEstructuraConIndividuo(_funcionAptitud.EstructuraBase.Vector, Estructura); }
        }

        public double[,] Matriz
        {
            get { return Utilidades.ConvertirVectorEnMatriz(Vector); }
        }

        public double Inconsistencia
        {
            get
            {
                if(_inconsistencia == null)
                    _inconsistencia = Utilidades.CalcularConsistencia(Matriz);
                return (double)_inconsistencia;
            }
        }

        public object Clone()
        {
            return new Individuo
                       {
                           GeneracionNacimiento = GeneracionNacimiento,
                           Estructura = (Estructura.Clone() as double[]),
                           _funcionAptitud = _funcionAptitud,
                           _inconsistencia = _inconsistencia,
                           _aptitud = _aptitud
                       };
        }
        
        public Individuo()
        {
        }

        public Individuo(IFuncionAptitud funcionAptitud)
        {
            _funcionAptitud = funcionAptitud;
        }

        public Individuo(int cantidadCaracteristicas, IFuncionAptitud funcionAptitud) : this(funcionAptitud)
        {
            Estructura = new double[cantidadCaracteristicas];
        }

        public static Individuo GenerarIndividuoAleatorio(int cantidadCaracteristicas, IFuncionAptitud funcionAptitud)
        {
            var individuo = new Individuo(cantidadCaracteristicas, funcionAptitud);
            individuo.Estructura = GenerarEstructuraAleatoria(cantidadCaracteristicas);
            return individuo;
        }

        public static double[] GenerarEstructuraAleatoria(int cantidadCaracteristicas)
        {
            var vector = new double[cantidadCaracteristicas];
            for (int i = 0; i < cantidadCaracteristicas; i++)
            {
                vector[i] = Utilidades.ValorAleatorioEscalaFundamental();
            }
            return vector;
        }

        public override bool Equals(object obj)
        {
            var individuo = obj as Individuo;
            return individuo != null && Estructura.Equals(individuo.Estructura);
        }
    }
}
