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
        public int EtiquetaSeleccionada { get; set; }
        public int MaximaEtiqueta { get; private set; }

        public CriterioILViewModel(string nombre, int valorActual, int cantidadEtiquetas)
        {
            Nombre = nombre;
            MaximaEtiqueta = cantidadEtiquetas - 1;
            EtiquetaSeleccionada = valorActual;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
