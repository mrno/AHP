﻿using System.Globalization;
using GeneticResearcher.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class MatrizViewModel : INotifyPropertyChanged
    {
        #region Atributos

        private ValoracionAHPViewModel _valoracionAHPViewModel;

        #endregion

        #region Constructores

        public MatrizViewModel(ValoracionAHPViewModel valoracion, double[,] matriz, IEnumerable<string> elementos)
        {
            _valoracionAHPViewModel = valoracion;
            Elementos = elementos;
            Matriz = matriz;
        }

        #endregion

        #region Comandos

        #endregion

        #region Propiedades

        public IEnumerable<string> Elementos { get; set; }
        public ObservableCollection<FilaAHPViewModel> Filas { get; set; }
        public double[,] Matriz
        {
            get
            {
                if (Filas == null)
                {
                    return new double[0, 0];
                }
                //else
                var dimension = Filas.Count;
                var matrix = new double[dimension, dimension];
                foreach (var row in Filas)
                {
                    var rowIndex = Filas.IndexOf(row);
                    foreach (var cell in row.Celdas)
                    {
                        var cellIndex = row.Celdas.IndexOf(cell);
                        matrix[rowIndex, cellIndex] = cell.Comparador.ValorImportancia;
                    }
                }
                return matrix;
            }
            set
            {
                var dimension = value.GetLength(0);

                if (Filas == null)
                {
                    Filas = new ObservableCollection<FilaAHPViewModel>();
                }

                if (dimension > Filas.Count)
                {
                    //agrega las filas que faltan
                    for (int i = Filas.Count; i < dimension; i++)
                    {
                        Filas.Add(new FilaAHPViewModel { Celdas = new ObservableCollection<CeldaAHPViewModel>() });
                    }

                    //en cada fila agrega las celdas que faltan
                    foreach (var row in Filas)
                    {
                        var i = Filas.IndexOf(row);
                        for (int j = row.Celdas.Count; j < dimension; j++)
                        {
                            var celda = new CeldaAHPViewModel(_valoracionAHPViewModel, Elementos.ElementAt(i),
                                                              Elementos.ElementAt(j), value[i, j]);
                            celda.ValorCeldaModificada += () => { _valoracionAHPViewModel.MatrizSeleccionadaEditada(); };
                            row.Celdas.Add(celda);
                        }
                    }

                    foreach (var fila in Filas)
                    {
                        var indiceFila = Filas.IndexOf(fila);
                        foreach (var celda in fila.Celdas)
                        {
                            var indiceCelda = fila.Celdas.IndexOf(celda);
                            celda.CeldaOpuesta = Filas.ElementAt(indiceCelda).Celdas.ElementAt(indiceFila);
                        }
                    }
                }
                else
                {
                    if (dimension < Filas.Count)
                    {
                        var oldOrder = Filas.Count;
                        for (int i = dimension; i < oldOrder; i++)
                        {
                            Filas.RemoveAt(dimension);
                        }
                        foreach (var row in Filas)
                        {
                            for (int i = dimension; i < oldOrder; i++)
                            {
                                row.Celdas.RemoveAt(dimension);
                            }
                        }
                    }
                }

                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        var celda = Filas.ElementAt(i).Celdas.ElementAt(j);
                        celda.Comparador.ValorImportancia = value[i, j];
                        celda.PosX = i;
                        celda.PosY = j;
                    }
                }
                OnPropertyChanged("Rows");
            }
        }

        public bool Completa { get { return !Filas.Any(x => x.Celdas.Any(y => y.Valor == 0)); } }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }


    public class FilaAHPViewModel
    {
        #region Atributos

        #endregion

        #region Constructores
        
        #endregion

        #region Comandos

        #endregion

        #region Propiedades

        public ObservableCollection<CeldaAHPViewModel> Celdas { get; set; }
        public CeldaAHPViewModel CeldaSeleccionada { get { return Celdas.FirstOrDefault(x => x.Seleccionada); } }

        #endregion
    }

    public class CeldaAHPViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Delegados

        public delegate void CeldaModificada();

        public event CeldaModificada ValorCeldaModificada;

        #endregion

        #region Atributos

        private bool _seleccionada;
        private double _valor;
        private bool _muestraSugerencia;
        private double _valorSugerido;
        private ValoracionAHPViewModel _valoracionAHPViewModel;

        #endregion

        #region Constructores

        public CeldaAHPViewModel(ValoracionAHPViewModel valoracionAHPViewModel, string elementoIzquierda, string elementoDerecha, double valor = 0)
        {
            _valoracionAHPViewModel = valoracionAHPViewModel;
            Comparador = new CompararElementosAHPViewModel(this, elementoIzquierda, elementoDerecha);
            Valor = valor;
            GuardarValorCambiado = new RelayCommand(GuardarCambioDeCelda);
        }

        #endregion

        #region Comandos

        #endregion

        #region Propiedades

        public CompararElementosAHPViewModel Comparador { get; private set; }
        public CeldaAHPViewModel CeldaOpuesta { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool Editable
        {
            get { return PosY != PosX; }
        }
        public bool Seleccionada
        {
            get { return _seleccionada; }
            set
            {
                _seleccionada = value;
                OnPropertyChanged("Seleccionada");
            }
        }
        
        public double Valor
        {
            get { return _valor; }
            set
            {
                _valor = value;
                OnPropertyChanged("Valor");
                Comparador.ActualizarValorSlider();
                ActualizarOpuesta();
                //ValorCeldaModificada();
            }
        }

        public bool MuestraSugerencia
        {
            get { return _muestraSugerencia; }
            set 
            { 
                _muestraSugerencia = value;
                Comparador.MuestraSugerencia = _muestraSugerencia;
                OnPropertyChanged("MuestraSugerencia");
            }
        }

        public double ValorSugerido
        {
            get { return _valorSugerido; }
            set
            {
                _valorSugerido = value;
                Comparador.ValorSugerido = _valorSugerido;
                OnPropertyChanged("ValorSugerido");
            }
        }

        //public string ValorTexto
        //{
        //    get
        //    {
        //        //importancia mayor o igual de los elementos
        //        if (_valor >= 1 && _valor <= 9)
        //        {
        //            return _valor.ToString(CultureInfo.InvariantCulture);
        //        }
        //        //importancia menor
        //        if (_valor < 1 && _valor > 0)
        //        {
        //            return "1/" + Math.Ceiling(1.0 / _valor).ToString(CultureInfo.InvariantCulture);
        //        }
        //        //importancia no asignada
        //        return "-";
        //    }
        //    set
        //    {
        //        if (value.Contains("/"))
        //        {
        //            _valor = 1.0 / int.Parse(value.Split('/').ElementAt(1));
        //        }
        //        else
        //        {
        //            _valor = int.Parse(value);
        //        }
        //        OnPropertyChanged("Valor");
        //        OnPropertyChanged("ValorTexto");
        //        Comparador.ActualizarValorSlider();
        //        ActualizarOpuesta();
        //        ValorCeldaModificada();
        //    }
        //}

        #endregion

        #region Comandos

        public RelayCommand GuardarValorCambiado { get; set; }
        private void GuardarCambioDeCelda()
        {
            if (PosY > PosX)
            {
                //este es el caso en que el número 
                //de columna sea mayor que el de fila (arriba de la diagonal principal)
                _valoracionAHPViewModel.MatrizSeleccionadaModificada(PosX, PosY - PosX - 1, Valor);
            }
            else
            {
                //si está del lado de abajo
                _valoracionAHPViewModel.MatrizSeleccionadaModificada(PosY, PosX - PosY - 1, 1.0/Valor);
            }
        }

        #endregion

        #region Metodos

        private void ActualizarOpuesta()
        {
            if(CeldaOpuesta != null)
                CeldaOpuesta.Actualizar(Valor);
        }

        private void Actualizar(double valor)
        {
            _valor = 1.0/valor;
            OnPropertyChanged("Valor");
            OnPropertyChanged("ValorTexto");
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Implementation of IDataErrorInfo

        public string this[string propertyName]
        {
            get
            {
                if (propertyName == "Valor")
                {
                    //return "asd";
                }
                return null;
            }
        }

        public string Error { get; private set; }

        #endregion
    }
}