using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class OrdenImportanciaAHPViewModel : INotifyPropertyChanged
    {
        public OrdenImportanciaAHPViewModel(List<string> elementos)
        {
            var elementosAPriorizar = (from c in elementos
                                        select new ElementoPriorizadoAHPViewModel(elementos)).ToList();
            ElementosPriorizados = new ReadOnlyCollection<ElementoPriorizadoAHPViewModel>(elementosAPriorizar);
        }

        public ReadOnlyCollection<ElementoPriorizadoAHPViewModel> ElementosPriorizados { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ElementoPriorizadoAHPViewModel : INotifyPropertyChanged
    {
        public IEnumerable<string> ElementosDisponibles { get; private set; }
        public string ElementoSeleccionado { get; set; }

        public bool ElementoComparacionIzquiera
        {
            get { return true; }
        }

        public bool ElementoComparacionDerecha { get; set; }

        public ElementoPriorizadoAHPViewModel(IEnumerable<string> elementos)
        {
            ElementosDisponibles = elementos;
            ElementoSeleccionado = elementos.First();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
