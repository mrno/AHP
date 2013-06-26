using GeneticResearcher.Command;
using sisexperto.Entidades.IL;
using sisExperto.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class ValoracionILViewModel : INotifyPropertyChanged
    {
        #region Delegados

        public delegate void ValoracionModificada(int alternativa, int criterio, int valor);

        public event ValoracionModificada ValoracionDeCriterioModificada;

        #endregion

        #region Atributos
        
        private ValorarAlternativaILViewModel _alternativaSeleccionada;
        private IEnumerable<ValorarAlternativaILViewModel> _alternativasDisponibles; 

        #endregion

        #region Constructores

        public ValoracionILViewModel(IEnumerable<Etiqueta> etiquetas, IEnumerable<AlternativaIL> alternativaILs)
        {
            Etiquetas =
                new ReadOnlyCollection<string>(
                    etiquetas.Select(x => etiquetas.ToList().IndexOf(x) + " - " + x.Nombre).Reverse().ToList());
            _alternativasDisponibles =
                new List<ValorarAlternativaILViewModel>(
                    alternativaILs.Select(
                        x => new ValorarAlternativaILViewModel(this, x.Nombre, x.ValorCriterios, etiquetas.Count())));
            AlternativaSeleccionada = AlternativasIL.First();
            MostrarAlternativa = new RelayCommand<ValorarAlternativaILViewModel>(CambiarAlternativaSeleccionada);
        }

        #endregion

        #region Propiedades

        public IEnumerable<ValorarAlternativaILViewModel> AlternativasIL { get { return _alternativasDisponibles; } }

        public ReadOnlyCollection<string> Etiquetas { get; private set; }

        public ValorarAlternativaILViewModel AlternativaSeleccionada
        {
            get { return _alternativaSeleccionada; }
            set
            {
                _alternativaSeleccionada = value;
                OnPropertyChanged("AlternativaSeleccionada");
            }
        }

        #endregion

        #region Comandos

        public RelayCommand<ValorarAlternativaILViewModel> MostrarAlternativa { get; set; }
        private void CambiarAlternativaSeleccionada(ValorarAlternativaILViewModel alternativaIL)
        {
            AlternativaSeleccionada = alternativaIL;
        }

        #endregion

        #region Metodos

        public void ValoracionTrackModificada(int criterio)
        {
            int alternativa = AlternativasIL.ToList().IndexOf(AlternativaSeleccionada);
            int valor = AlternativaSeleccionada.CriteriosIL.ElementAt(criterio).EtiquetaSeleccionada;
            ValoracionDeCriterioModificada(alternativa, criterio, valor);
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
