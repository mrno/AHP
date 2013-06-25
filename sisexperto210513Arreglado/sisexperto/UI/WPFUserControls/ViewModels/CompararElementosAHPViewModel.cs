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

        //private double _valorImportancia;
        //public double ValorImportancia
        //{
        //    get { return _valorImportancia; }
        //    set
        //    {
        //        _valorImportancia = value;
        //        OnPropertyChanged("ValorImportancia");
        //        _celdaAHP.ActualizarTextoPorSlider();
        //    }
        //}

        public double ValorImportancia
        {
            get { return _celdaAHP.Valor; }
            set
            {
                _celdaAHP.Valor = value;
                OnPropertyChanged("ValorImportancia");
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
