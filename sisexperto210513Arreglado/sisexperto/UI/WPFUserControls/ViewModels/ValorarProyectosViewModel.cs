using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class ValorarProyectosViewModel : INotifyPropertyChanged
    {
        private ValoracionAHPViewModel _valoracionAHPViewModel;
        public ValoracionAHPViewModel ValoracionAHP
        {
            get { return _valoracionAHPViewModel; }
            set
            {
                _valoracionAHPViewModel = value;
                OnPropertyChanged("TieneAHP");

                if (value == null) return;
                OnPropertyChanged("MostrarAHP");
                OnPropertyChanged("MostrarIL");
                OnPropertyChanged("ValoracionAHP");
            }
        }

        private ValoracionILViewModel _valoracionILViewModel;
        public ValoracionILViewModel ValoracionIL
        {
            get { return _valoracionILViewModel; }
            set
            {
                _valoracionILViewModel = value;
                OnPropertyChanged("TieneIL");

                if (value == null) return;
                OnPropertyChanged("MostrarIL");
                OnPropertyChanged("ValoracionIL");
            }
        }

        public bool TieneAHP
        {
            get { return ValoracionAHP != null; }
        }

        public bool TieneIL
        {
            get { return ValoracionIL != null; }
        }

        private bool _mostrarAHP;

        public bool MostrarAHP
        {
            get { return _mostrarAHP; }
            set
            {
                _mostrarAHP = value;
                OnPropertyChanged("MostrarAHP");
                OnPropertyChanged("MostrarIL");
            }
        }

        public bool MostrarIL
        {
            get { return TieneIL && !TieneAHP; }
        }

        public ValorarProyectosViewModel()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
