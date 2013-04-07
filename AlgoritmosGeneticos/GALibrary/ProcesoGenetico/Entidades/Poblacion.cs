using System.Collections.Generic;
using System.Linq;
using System;
using GALibrary.Complementos;

namespace GALibrary.ProcesoGenetico.Entidades
{
    public class Poblacion : ICloneable
    {
        #region propiedades

        public int Generacion { get; set; }
        public List<Individuo> Individuos { get; set; }

        public double AptitudMedia
        {
            get
            {
                return (from c in Individuos
                        select c.Aptitud).Average();
            }
        }
        
        public Individuo MejorIndividuo 
        {
            get
            {
                return (from c in Individuos
                        orderby c.Aptitud descending
                        select c).FirstOrDefault();
            } 
        }

        public Individuo PeorIndividuo
        {
            get
            {
                return (from c in Individuos
                        orderby c.Aptitud ascending
                        select c).FirstOrDefault();
            }
        }
        
        #endregion

        #region métodos

        public Poblacion()
        {
            Individuos = new List<Individuo>();
        }

        public Poblacion(int generacion)
        {
            Generacion = generacion;
            Individuos = new List<Individuo>();
        }

        public Poblacion(int generacion, List<Individuo> individuos)
        {
            Generacion = generacion;
            Individuos = individuos;
        }

        public static Poblacion GenerarPoblacionInicial(int cantidadIndividuos, Estructura estructuraBase, Estructura estructuraObjetivo, string funcionAptitud)
        {
            var cantidadCaracteristicasIndividuo = estructuraBase.Vector.CantidadValoresFaltantes();

            var factory = new FuncionesAptitud.FuncionAptitudFactory();

            var individuos = new List<Individuo>();
            for (int i = 0; i < cantidadIndividuos; i++)
            {
                var funcion = factory.CreateInstance(funcionAptitud);
                funcion.EstructuraBase = estructuraBase;
                funcion.EstructuraObjetivo = estructuraObjetivo;
                individuos.Add(Individuo.GenerarIndividuoAleatorio(cantidadCaracteristicasIndividuo, funcion));
            }
            return new Poblacion(0, individuos);
        }

        //public void ActualizarAptitudIndividuos()
        //{
        //    foreach (var individuo in Individuos)
        //    {
        //        individuo.CalcularAptitudIndividuo();
        //    }
        //}

        #endregion
        
        public object Clone()
        {
            var individuos = (from c in Individuos
                              select (Individuo) c.Clone()).ToList();
            return new Poblacion() {Generacion = Generacion, Individuos = individuos};
        }
    }
}
