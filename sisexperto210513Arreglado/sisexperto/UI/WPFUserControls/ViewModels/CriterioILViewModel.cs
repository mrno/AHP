using GeneticResearcher.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class CriterioILViewModel : INotifyPropertyChanged
    {
        public string Nombre { get; private set; }
        private ValorarAlternativaILViewModel _alternativaILViewModel;
        private int _etiquetaSeleccionada;
        public int EtiquetaSeleccionada
        {
            get { return _etiquetaSeleccionada; }
            set
            {
                _etiquetaSeleccionada = value;
                OnPropertyChanged("EtiquetaSeleccionada");
            }
        }

        public int MaximaEtiqueta { get; private set; }

        public CriterioILViewModel(ValorarAlternativaILViewModel alternativaIL, string nombre, int valorActual, int cantidadEtiquetas)
        {
            _alternativaILViewModel = alternativaIL;
            Nombre = nombre;
            MaximaEtiqueta = cantidadEtiquetas - 1;
            EtiquetaSeleccionada = valorActual;
            GuardarValorCambiado = new RelayCommand(GuardarCambios);
        }

        #region Comandos

        public RelayCommand GuardarValorCambiado { get; private set; }
        private void GuardarCambios()
        {
            _alternativaILViewModel.GuardarCambioCriterio(this);
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
