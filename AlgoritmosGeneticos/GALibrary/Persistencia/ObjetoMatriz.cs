using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using GALibrary.Complementos;

namespace GALibrary.Persistencia
{
    public class ObjetoMatriz : ICloneable
    {
        #region Propiedades

        public virtual int Id { get; set; }
        public virtual ConjuntoMatriz ConjuntoMatriz { get; set; }
        public virtual ICollection<FilaMatriz> Filas { get; set; }
        public virtual double? Inconsistencia { get; set; }
        public virtual bool Completa { get; set; }
        public virtual int Dimension { get; set; }
        

        public virtual ObjetoMatriz MatrizCompleta { get; set; }
        public virtual ICollection<ObjetoMatriz> MatricesIncompletas { get; set; }

        public virtual ObjetoMatriz MatrizMejorada { get; set; }
        
        #endregion

        public ObjetoMatriz()
        {
        }

        public ObjetoMatriz(int dimension, bool autogenerarMatriz = true, bool consistente = true, int matricesConFaltantes = 3)
        {
            Dimension = dimension;
            if (autogenerarMatriz)
            {
                if (consistente)
                {
                    AutoGenerarMatrizConsistente();
                }
                else
                {
                    AutoGenerarMatrizInconsistente();
                }
                Completa = true;
                Inconsistencia = Utilidades.CalcularConsistencia(Matriz);

                if (matricesConFaltantes > 0)
                {
                    GenerarMatricesConValoresFaltantes(matricesConFaltantes);
                }
            }
        }

        public NivelInconsistencia NivelDeInconsistencia 
        { 
            get
            {
                if(Inconsistencia == null)
                    return NivelInconsistencia.NoTiene;
                if(Inconsistencia.Entre(0.0,0.1))
                    return NivelInconsistencia.Consistente;
                if (Inconsistencia.Entre(0.1, 0.3))
                    return NivelInconsistencia.Bajo;
                return Inconsistencia.Entre(0.3, 0.5) ? NivelInconsistencia.Medio : NivelInconsistencia.Alto;
            }
        }

        #region Matriz
        
        public double PorcentajeCompleta
        {
            get { return Vector.PorcentajeCompleto(); }
        }
        
        public double[,] Matriz
        {
            get
            {
                var matriz = new double[Dimension, Dimension];
                
                for (int fila = 0; fila < Dimension; fila++)
                {
                    matriz[fila, fila] = 1;
                    for (int columna = fila + 1; columna < Dimension; columna++)
                    {
                        matriz[fila, columna] = Filas.ElementAt(fila).Celdas.ElementAt(columna - fila - 1).Valor;
                        matriz[columna, fila] = 1.0 / (Filas.ElementAt(fila).Celdas.ElementAt(columna - fila - 1).Valor);
                    }
                }

                return matriz;
            }
            set
            {
                if (Filas == null)
                {
                    Filas = new List<FilaMatriz>();

                    for (int fila = 0; fila < Dimension - 1; fila++)
                    {
                        var celdas = new List<CeldaMatriz>();

                        for (int columna = fila + 1; columna < Dimension; columna++)
                        {
                            celdas.Add(new CeldaMatriz {Valor = value[fila, columna]});
                        }

                        Filas.Add(new FilaMatriz {Celdas = celdas});
                    }
                }
                else
                {
                    for (int fila = 0; fila < Dimension - 1; fila++)
                    {
                        for (int columna = fila + 1; columna < Dimension; columna++)
                        {
                            Filas.ElementAt(fila).Celdas.ElementAt(columna - fila - 1).Valor = value[fila, columna];
                        }
                    }
                }
            }
        }
        
        public double[] Vector
        {
            get
            {
                var vector = new double[Utilidades.CalcularLongitudVector(Dimension)];
                var posicion = 0;
                foreach (var fila in Filas)
                {
                    foreach (var celda in fila.Celdas)
                    {
                        vector[posicion] = celda.Valor;
                        posicion++;
                    }
                }

                return Utilidades.ConvertirMatrizEnVector(Matriz);
            }

            set
            {
                if(Filas == null)
                {
                    Filas = new List<FilaMatriz>();
                    for (int fila = 0; fila < Dimension - 1; fila++)
                    {
                        var nuevaFila = new FilaMatriz {Celdas = new List<CeldaMatriz>()};
                        for (int columna = fila + 1 ; columna < Dimension; columna++)
                        {
                            nuevaFila.Celdas.Add(new CeldaMatriz());
                        }
                        Filas.Add(nuevaFila);
                    }
                }

                var posicion = 0;
                foreach (var fila in Filas)
                {
                    foreach (var celda in fila.Celdas)
                    {
                        celda.Valor = value[posicion];
                        posicion++;
                    }
                }
            }
        }

        private void AutoGenerarMatrizConsistente()
        {
            Matriz = Utilidades.GenerarMatrizConsistente(Dimension);
        }

        private void AutoGenerarMatrizInconsistente()
        {
            var vector = new double[Utilidades.CalcularLongitudVector(Dimension)];
            for (int posicion = 0; posicion < vector.Length; posicion++)
            {
                vector[posicion] = Utilidades.ValorAleatorioEscalaFundamental();
            }
            Vector = vector;
        }

        private void GenerarMatricesConValoresFaltantes(int cantidadCopias)
        {
            MatricesIncompletas = new List<ObjetoMatriz>();

            var numeroElementos = Vector.Length;
            var elementosEliminables = Math.Floor(numeroElementos/2.0);
            var elementosNoEliminables = numeroElementos - elementosEliminables;

            double porcentajeInicial = elementosNoEliminables/numeroElementos;

            var step = 1.0; // elementosEliminables
            if(elementosEliminables > cantidadCopias)
            {
                step = numeroElementos*(1.0 - porcentajeInicial)/(cantidadCopias);// - 1);
            }
            else
            {
                cantidadCopias = (int)elementosEliminables;
            }

            for (int i = 0; i < cantidadCopias; i++)
            {
                var eliminar = (int)Math.Floor(elementosEliminables - i*step);
                //var eliminar = Math.Floor(elementosEliminables - i * step);

                var matrizObjeto = (ObjetoMatriz)Clone();
                MatricesIncompletas.Add(matrizObjeto);
                matrizObjeto.Completa = false;
                matrizObjeto.Matriz = Utilidades.GenerarMatrizConValoresFaltantes(matrizObjeto.Vector, eliminar);

                //var vector = matrizObjeto.Vector;
                
                //while (vector.Count(x => x.Equals(CeldaMatriz.Incompleto)) < eliminar)
                //{
                //    vector[Random.Next(0, vector.Length)] = CeldaMatriz.Incompleto;
                //}
                //matrizObjeto.Vector = vector;
            }
        }
        
        #endregion

        public object Clone()
        {
            var objetoMatriz = new ObjetoMatriz
                                   {
                                       Dimension = Dimension,
                                       Vector = (double[]) Vector.Clone(),
                                       Inconsistencia = null,
                                       MatrizCompleta = this,
                                   };
            return objetoMatriz;
        }
    }

    public class FilaMatriz
    {
        #region Propiedades

        public virtual int Id { get; set; }
        public virtual ObjetoMatriz ObjetoMatriz { get; set; }
        public virtual ICollection<CeldaMatriz> Celdas { get; set; }

        #endregion
    }

    public class CeldaMatriz
    {
        #region Propiedades

        public virtual int Id { get; set; }
        public virtual FilaMatriz FilaMatriz { get; set; }
        public virtual double Valor { get; set; }

        [NotMapped]
        public const int Incompleto = -1;

        #endregion
    }
}
