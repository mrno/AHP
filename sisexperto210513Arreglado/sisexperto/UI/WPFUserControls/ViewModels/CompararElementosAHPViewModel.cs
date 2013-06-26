using GeneticResearcher.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class CompararElementosAHPViewModel : INotifyPropertyChanged
    {
        #region Atributos

        private bool _muestraSugerencia;
        private double _valorSugerido;
        private readonly CeldaAHPViewModel _celdaAHP;

        #endregion

        #region Constructores

        public CompararElementosAHPViewModel(CeldaAHPViewModel celda, string elementoIzquierda, string elementoDerecha)
        {
            _celdaAHP = celda;
            ElementoIzquierda = elementoIzquierda;
            ElementoDerecha = elementoDerecha;
            GuardarValorCambiado = new RelayCommand(GuardarCambioDeCelda);
        }

        #endregion

        #region Propiedades

        public string Titulo
        {
            get 
            {
                return string.Format("Importancia que tiene {0} respecto de {1}", 
                    ElementoIzquierda, ElementoDerecha);
            }
        }
        public string ElementoIzquierda { get; set; }
        public string ElementoDerecha { get; set; }

        public bool MuestraSugerencia
        {
            get { return _muestraSugerencia; }
            set
            {
                _muestraSugerencia = value;
                OnPropertyChanged("MuestraSugerencia");
            }
        }

        public bool ValorCoincideConSugerido
        {
            get { return ValorImportancia == ValorSugerido; }
        }

        public double ValorSugerido
        {
            get { return _valorSugerido; }
            set
            {
                _valorSugerido = value;
                OnPropertyChanged("ValorSugerido");
                OnPropertyChanged("ValorCoincideConSugerido");
            }
        }

        public double ValorImportancia
        {
            get { return _celdaAHP.Valor; }
            set
            {
                _celdaAHP.Valor = value;
                OnPropertyChanged("ValorImportancia");
                OnPropertyChanged("ValorCoincideConSugerido");
            }
        }

        #endregion

        #region Comandos

        public RelayCommand GuardarValorCambiado { get; set; }
        private void GuardarCambioDeCelda()
        {
            //SelectedOperators.Add(selectedOperator);
            //OnPropertyChanged("AvailableOperators");

            //SelectedOperator = selectedOperator;
            //OnPropertyChanged("SelectedOperator");
        }

        #endregion

        #region Metodos

        public void ActualizarValorSlider()
        {
            OnPropertyChanged("ValorImportancia");
        }

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
}
