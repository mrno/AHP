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

        public MatrizAHPViewModel(string nombre, List<string> elementos, double[,] matriz, bool completa, bool consistente)
        {
            Nombre = nombre;
            ElementosAComparar = new ObservableCollection<ElementoACompararViewModel>
                (elementos.Select(x => new ElementoACompararViewModel(x)).ToList());
            ImportanciaDeElementos = new OrdenImportanciaAHPViewModel(elementos);
            

            Matriz = new MatrizViewModel(new double[elementos.Count,elementos.Count], elementos)
                         {
                             Matriz = matriz
                         };
            Completa = completa;
            Consistente = consistente;
        }

        #endregion
        
        #region Propiedades

        public string Nombre { get; set; }
        public ObservableCollection<ElementoACompararViewModel> ElementosAComparar { get; private set; }
        public OrdenImportanciaAHPViewModel ImportanciaDeElementos { get; private set; }
        public MatrizViewModel Matriz { get; set; }

        
        public bool Completa { get; set; }
        public bool Consistente { get; set; }

        
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
