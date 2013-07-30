using System.Collections.Generic;
using System.Linq;
using System;
using GALibrary.Complementos;
using GALibrary.ProcesoGenetico.ConvergenciaPoblacion;
using GALibrary.ProcesoGenetico.FuncionesAptitud;

namespace GALibrary.ProcesoGenetico.Entidades
{
    public class Poblacion : ICloneable
    {
        #region propiedades

        public int Generacion { get; set; }
        public List<Individuo> Individuos { get; set; }
        private IConvergenciaPoblacion _convergenciaPoblacion;

        public int MaximaGeneracion { get; set; }

        public double Convergencia
        {
            get { return _convergenciaPoblacion.CalcularConvergencia(this); }
        }

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
        }

        public Poblacion(string tipoConvergencia)
        {
            var factoryConvergencia = new ConvergenciaPoblacionFactory();
            _convergenciaPoblacion = factoryConvergencia.CreateInstance(tipoConvergencia);
        }

        public Poblacion(int generacion, int maximaGeneracion, string tipoConvergencia)
            : this(tipoConvergencia)
        {
            Generacion = generacion;
            MaximaGeneracion = maximaGeneracion;
            Individuos = new List<Individuo>();
        }

        public Poblacion(int generacion, int maximaGeneracion, List<Individuo> individuos, string tipoConvergencia)
            : this(generacion, maximaGeneracion, tipoConvergencia)
        {
            Individuos = individuos;
        }

        public static Poblacion GenerarPoblacionInicial(int cantidadIndividuos, int maximaGeneracion, Estructura estructuraBase, string funcionAptitud, string tipoConvergencia)
        {
            var cantidadCaracteristicasIndividuo = estructuraBase.CantidadCaracteristicas;
            
            var factoryAptitud = new FuncionAptitudFactory();

            var individuos = new List<Individuo>();
            for (int i = 0; i < cantidadIndividuos; i++)
            {
                var funcion = factoryAptitud.CreateInstance(funcionAptitud);
                funcion.EstructuraBase = estructuraBase;
                individuos.Add(Individuo.GenerarIndividuoAleatorio(cantidadCaracteristicasIndividuo, funcion));
            }
            return new Poblacion(0, maximaGeneracion, individuos, tipoConvergencia);
        }
        
        #endregion
        
        public object Clone()
        {
            var individuos = (from c in Individuos
                              select (Individuo) c.Clone()).ToList();
            return new Poblacion
                       {
                           Generacion = Generacion,
                           Individuos = individuos,
                           MaximaGeneracion = MaximaGeneracion,
                           _convergenciaPoblacion = _convergenciaPoblacion
                       };
        }

    }
}
