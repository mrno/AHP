using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using GeneticResearcher.Command;
using sisexperto.Fachadas;
using System.Windows;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class MatrizAHPViewModel : INotifyPropertyChanged
    {
        #region Atributos

        private ValoracionAHPViewModel _valoracionAHPViewModel;

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


        #endregion

        #region Comandos
        
        //public RelayCommand<CeldaAHPViewModel> CambiarSeleccion { get; set; }
        //private void AlCambiarSeleccion(CeldaAHPViewModel celda)
        //{
        //    celda.Seleccionada = false;
        //    OnPropertyChanged("CeldaSeleccionada");
        //}

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
                    MessageBox.Show("Matriz consistente.");
                else
                {
                    //EjecutarSugerencias(matriz);
                }
            }
            else MessageBox.Show("La matriz debe estar completa para evaluar su consistencia.");
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
