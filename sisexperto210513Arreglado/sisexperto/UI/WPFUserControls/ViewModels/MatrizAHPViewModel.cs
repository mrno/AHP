using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using GeneticResearcher.Command;
using sisexperto.Entidades.AHP;
using sisexperto.Fachadas;
using System.Windows;
using sisexperto.UI.Clases;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class MatrizAHPViewModel : INotifyPropertyChanged
    {
        #region Atributos

        private ValoracionAHPViewModel _valoracionAHPViewModel;
        private SugerenciaViewModel _sugerenciaMostrada;
        private List<SugerenciaViewModel> _sugerencias;
        private bool _haySugerencias;

        #endregion

        #region Constructores

        public MatrizAHPViewModel(ValoracionAHPViewModel valoracionAHP, string nombre, List<string> elementos, double[,] matriz, bool consistente)
        {
            _valoracionAHPViewModel = valoracionAHP;
            Nombre = nombre;
            ElementosAComparar = new ObservableCollection<ElementoACompararViewModel>
                (elementos.Select(x => new ElementoACompararViewModel(x)).ToList());
            ImportanciaDeElementos = new OrdenImportanciaAHPViewModel(elementos);
            
            Matriz = new MatrizViewModel(valoracionAHP, new double[elementos.Count,elementos.Count], elementos)
                         {
                             Matriz = matriz
                         };

            Consistente = consistente;

            ComprobarConsistencia = new RelayCommand(ComprobarConsistenciaDeMatrizSeleccionada);
            SiguienteSugerencia = new RelayCommand(MostrarOtraSugerencia);
        }

        #endregion
        
        #region Propiedades

        public string Nombre { get; set; }
        public ObservableCollection<ElementoACompararViewModel> ElementosAComparar { get; private set; }
        public OrdenImportanciaAHPViewModel ImportanciaDeElementos { get; private set; }
        public MatrizViewModel Matriz { get; set; }
        
        public bool Completa
        { get { return Matriz.Completa; } }

        private bool _consistente;

        public bool Consistente
        {
            get { return _consistente; }
            set
            {
                _consistente = value;
                OnPropertyChanged("Consistente");
            }
        }

        public bool HaySugerencias
        {
            get { return _haySugerencias; }
            private set
            {
                _haySugerencias = value;
                OnPropertyChanged("HaySugerencias");
            }
        }

        #endregion

        #region Comandos
        
        //public RelayCommand<CeldaAHPViewModel> CambiarSeleccion { get; set; }
        //private void AlCambiarSeleccion(CeldaAHPViewModel celda)
        //{
        //    celda.Seleccionada = false;
        //    OnPropertyChanged("CeldaSeleccionada");
        //} 

        public RelayCommand SiguienteSugerencia { get; set; }
        private void MostrarOtraSugerencia()
        {
            MostrarSugerencia();
        }

        public RelayCommand ComprobarConsistencia { get; set; }
        private void ComprobarConsistenciaDeMatrizSeleccionada()
        {
            if (Completa)
            {
                Consistente = FachadaCalculos.Instance.CalcularConsistencia(Matriz.Matriz);
                _valoracionAHPViewModel.GuardarConsistencia();
                OnPropertyChanged("Consistente");
                OnPropertyChanged("Completa");
                if (Consistente)
                {
                    HaySugerencias = false;
                    if (_sugerenciaMostrada != null)
                    {
                        Matriz.Filas.ElementAt(_sugerenciaMostrada.Fila).Celdas.ElementAt(_sugerenciaMostrada.Columna).
                            MuestraSugerencia = false;
                        if (_sugerencias.Count > 0)
                            _sugerencias.RemoveAt(0);
                    }
                    MessageBox.Show("Matriz consistente.");
                }
                else
                {
                    MessageBox.Show("La matriz no está consistente.\n" +
                                    "Modifique los valores de las celdas y vuelva a evaluar la consistencia.\n" +
                                    "En rojo se encuentran valores sugeridos para ellas. " +
                                    "Con \"Siguiente Sugerencia\" puede cambiar la sugerencia actual.");
                    GenerarSugerencias(Matriz.Matriz);
                    HaySugerencias = true;
                    MostrarSugerencia();
                }
            }
            else MessageBox.Show("La matriz debe estar completa para evaluar su consistencia.");
        }

        #endregion

        #region Metodos

        private void GenerarSugerencias(double [,] matriz)
        {
            var listaSugerencias = new List<SugerenciaViewModel>();

            var sugerencias = FachadaCalculos.Instance.BuscarSugerencias(matriz);
            for (int i = 0; i < sugerencias.Count(); i += 3)
            {
                var fila = (int)(sugerencias.ElementAt(i).ElementAt(0));
                var columna = (int)(sugerencias.ElementAt(i).ElementAt(1));
                var valor = sugerencias.ElementAt(i).ElementAt(2);

                listaSugerencias.Add(new SugerenciaViewModel
                {
                    Fila = fila,
                    Columna = columna,
                    Valor = valor
                });
            }
            _sugerencias = listaSugerencias;
        }

        private void MostrarSugerencia()
        {
            if (_sugerenciaMostrada != null)
            {
                Matriz.Filas.ElementAt(_sugerenciaMostrada.Fila).Celdas.ElementAt(_sugerenciaMostrada.Columna).
                    MuestraSugerencia = false;
                if(_sugerencias.Count > 0)
                    _sugerencias.RemoveAt(0);
            }
            if(_sugerencias.Count > 0)
            {
                _sugerenciaMostrada = _sugerencias.First();
                var celda = Matriz.Filas.ElementAt(_sugerenciaMostrada.Fila).Celdas.ElementAt(_sugerenciaMostrada.Columna);
                celda.MuestraSugerencia = true;
                celda.ValorSugerido = _sugerenciaMostrada.Valor;
            }
            else
            {
                MessageBox.Show("No hay más sugerencias.");
                HaySugerencias = false;
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
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
