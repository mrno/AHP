using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GeneticResearcher.Command;
using sisExperto.Entidades;
using sisexperto.Entidades.AHP;
using System.ComponentModel;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class ValoracionAHPViewModel : INotifyPropertyChanged
    {
        #region Atributos

        private ReadOnlyCollection<MatrizAHPViewModel> _matricesAHPAlternativas;

        #endregion

        #region Constructores
        
        public ValoracionAHPViewModel(IEnumerable<Criterio> criterios, CriterioMatriz matrizCriterio,
                                      IEnumerable<Alternativa> alternativas,
                                      IEnumerable<AlternativaMatriz> matricesAlternativas)
        {
            MatrizCriterio = new MatrizAHPViewModel("Comparación de Criterios",
                                                       criterios.Select(x => x.Nombre).ToList())
            {
                Matriz = matrizCriterio.Matriz,
                Completa = matrizCriterio.Completa,
                Consistente = matrizCriterio.Consistencia
            };

            var matricesAlternativasModels =
                criterios.Select(
                    criterio =>
                    new MatrizAHPViewModel(criterio.Nombre,
                                           alternativas.Select(x => x.Nombre).ToList())
                                           {
                                               Matriz = matricesAlternativas.ElementAt(criterios.ToList().IndexOf(criterio)).Matriz,
                                               Completa = matrizCriterio.Completa,
                                               Consistente = matrizCriterio.Consistencia
                                           }).ToList();

            _matricesAHPAlternativas = new ReadOnlyCollection<MatrizAHPViewModel>(matricesAlternativasModels);

            MatrizSeleccionada = MatrizCriterio;

            MostrarMatrizComando = new RelayCommand<MatrizAHPViewModel>(MostrarMatriz);
        }

        #endregion

        #region Propiedades

        public MatrizAHPViewModel MatrizCriterio { get; private set; }

        public IEnumerable<MatrizAHPViewModel> MatricesPorCriterio
        {
            get { return _matricesAHPAlternativas; }
        }
        
        private MatrizAHPViewModel _matrizSeleccionada;

        public MatrizAHPViewModel MatrizSeleccionada
        {
            get { return _matrizSeleccionada; }
            set
            {
                _matrizSeleccionada = value;
                OnPropertyChanged("MatrizSeleccionada");
            }
        }

        #endregion

        #region Comandos

        public RelayCommand<MatrizAHPViewModel> MostrarMatrizComando { get; set; }
        private void MostrarMatriz(MatrizAHPViewModel matrizAHPViewModel)
        {
            if (MatrizSeleccionada == matrizAHPViewModel) return;
            MatrizSeleccionada = matrizAHPViewModel;
            OnPropertyChanged("MatrizSeleccionada");
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
