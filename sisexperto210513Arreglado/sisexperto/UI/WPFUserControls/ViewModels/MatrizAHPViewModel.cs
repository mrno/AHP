using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using GeneticResearcher.Command;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class MatrizAHPViewModel : INotifyPropertyChanged
    {
        #region Constructores

        public MatrizAHPViewModel(string nombre, List<string> elementos)
        {
            Nombre = nombre;
            ElementosAComparar = new ObservableCollection<ElementoACompararViewModel>(elementos.Select(x => new ElementoACompararViewModel(x)).ToList());
            ImportanciaDeElementos = new OrdenImportanciaAHPViewModel(elementos);

            Matriz = new double[elementos.Count,elementos.Count];
        }

        #endregion
        
        #region Propiedades

        public string Nombre { get; set; }
        public ObservableCollection<FilaAHPViewModel> Filas { get; set; }
        public ObservableCollection<ElementoACompararViewModel> ElementosAComparar { get; private set; }
        public OrdenImportanciaAHPViewModel ImportanciaDeElementos { get; private set; }

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
                        matrix[rowIndex, cellIndex] = cell.Valor;
                    }
                }
                return matrix;
            }
            set
            {
                var dimension = value.GetLength(0);

                if (Filas == null)// || dimension != Rows.Count)
                {
                    Filas = new ObservableCollection<FilaAHPViewModel>();
                    for (int i = 0; i < dimension; i++)
                    {
                        var row = new FilaAHPViewModel { Celdas = new ObservableCollection<CeldaAHPViewModel>() };
                        for (int j = 0; j < dimension; j++)
                        {
                            row.Celdas.Add(new CeldaAHPViewModel());
                        }
                        Filas.Add(row);
                    }
                }

                if (dimension > Filas.Count)
                {
                    for (int i = Filas.Count; i < dimension; i++)
                    {
                        Filas.Add(new FilaAHPViewModel() { Celdas = new ObservableCollection<CeldaAHPViewModel>() });
                    }

                    foreach (var row in Filas)
                    {
                        for (int i = row.Celdas.Count; i < dimension; i++)
                        {
                            row.Celdas.Add(new CeldaAHPViewModel());
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
                        celda.Valor = value[i, j];
                        celda.PosX = i;
                        celda.PosY = j;
                    }
                }
                OnPropertyChanged("Rows");
            }
        }
        public bool Completa { get; set; }
        public bool Consistente { get; set; }

        public CeldaAHPViewModel CeldaSeleccionada
        {
            get { return Filas.First(x => x.CeldaSeleccionada != null).CeldaSeleccionada; }
        }
        
        #endregion

        #region Comandos
        
        private RelayCommand<CeldaAHPViewModel> CambiarSeleccion { get; set; }
        public void AlCambiarSeleccion(CeldaAHPViewModel celda)
        {
            celda.Seleccionada = false;
            OnPropertyChanged("CeldaSeleccionada");
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class FilaAHPViewModel
    {
        public ObservableCollection<CeldaAHPViewModel> Celdas { get; set; }

        public CeldaAHPViewModel CeldaSeleccionada { get { return Celdas.FirstOrDefault(x => x.Seleccionada); } }
    }

    public class CeldaAHPViewModel : INotifyPropertyChanged
    {
        private double _valor;

        public double Valor
        {
            get { return _valor; }
            set
            {
                _valor = value;
                OnPropertyChanged("ValorTexto");
            }
        }

        public string ValorTexto
        {
            get
            {
                if(_valor == 0)
                {
                    return "-";
                }
                if (_valor >= 1)
                {
                    return _valor.ToString();
                }
                return "1/" + Math.Ceiling(1.0/_valor).ToString();
            }
            set
            {
                if (value.Contains("/"))
                {
                    _valor = 1.0 / int.Parse(value.Split('/').ElementAt(1));
                }
                else
                {
                    _valor = int.Parse(value);
                }
                OnPropertyChanged("Valor");
            }
        }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public bool Editable
        {
            get { return PosY != PosX; }
        }

        private bool _seleccionada;
        public bool Seleccionada
        {
            get { return _seleccionada; }
            set
            {
                _seleccionada = value;
                OnPropertyChanged("Seleccionada");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class ElementoACompararViewModel : INotifyPropertyChanged
    {
        public string Elemento { get; set; }
        public bool ElementoComparacionIzquiera { get; set; }
        public bool ElementoComparacionDerecha { get; set; }

        public ElementoACompararViewModel(string elemento)
        {
            Elemento = elemento;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
