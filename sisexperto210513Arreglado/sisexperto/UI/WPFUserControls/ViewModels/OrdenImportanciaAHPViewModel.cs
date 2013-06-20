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
            var elementosAPriorizar = new List<ElementoPriorizadoAHPViewModel>();
            foreach (string c in elementos)
            {
                var elem = new ElementoPriorizadoAHPViewModel(elementos);
                
                elementosAPriorizar.Add(elem);
            }

            ElementosPriorizados = new ObservableCollection<ElementoPriorizadoAHPViewModel>(elementosAPriorizar);
        }

        public ObservableCollection<ElementoPriorizadoAHPViewModel> ElementosPriorizados { get; set; }

        public bool ElementosSeleccionadosDistintos
        {
            get
            {
                return (from model in ElementosPriorizados
                        group model by model.ElementoSeleccionado
                        into grupo
                        select new {grupo.Key, Count = grupo.Count()}).Any(x => x.Count > 1);
            }
        }

        #region INotifyPropertyChanged Members
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class ElementoPriorizadoAHPViewModel : INotifyPropertyChanged
    {
        public IEnumerable<string> ElementosDisponibles { get; private set; }

        private string _seleccionado;

        public string ElementoSeleccionado
        {
            get { return _seleccionado; }
            set
            {
                _seleccionado = value;
                OnPropertyChanged("ElementoSeleccionado");
            }
        }

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
