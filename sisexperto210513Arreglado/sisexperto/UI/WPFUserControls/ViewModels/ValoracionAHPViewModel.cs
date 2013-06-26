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
        #region Delegados

        public delegate void MatrizAHPModificada(int? matriz, int fila, int columna, double valor);
        public delegate void MatrizAHPConsistente(int? matriz, bool consistencia);

        public event MatrizAHPModificada MatrizCriterioModificada;
        public event MatrizAHPModificada MatrizAlternativaModificada;

        public event MatrizAHPConsistente MatrizCriterioConsistente;
        public event MatrizAHPConsistente MatrizAlternativasConsistente;

        #endregion

        #region Atributos

        private MatrizAHPViewModel _matrizSeleccionada;
        private ReadOnlyCollection<MatrizAHPViewModel> _matricesAHPAlternativas;

        #endregion

        #region Constructores
        
        public ValoracionAHPViewModel(IEnumerable<Criterio> criterios, CriterioMatriz matrizCriterio,
                                      IEnumerable<Alternativa> alternativas,
                                      IEnumerable<AlternativaMatriz> matricesAlternativas)
        {
            MatrizCriterio = new MatrizAHPViewModel(this, "Criterios",
                                                    criterios.Select(x => x.Nombre).ToList(),
                                                    matrizCriterio.Matriz,
                                                    matrizCriterio.Consistencia);
        

            var matricesAlternativasModels =
                criterios.Select(
                    criterio =>
                    new MatrizAHPViewModel(this, criterio.Nombre,
                                           alternativas.Select(x => x.Nombre).ToList(),
                                           matricesAlternativas.ElementAt(criterios.ToList().IndexOf(criterio)).Matriz,
                                           matricesAlternativas.ElementAt(criterios.ToList().IndexOf(criterio)).Consistencia)).ToList();

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

        #region Metodos

        public void MatrizSeleccionadaModificada(int fila, int columna, double valor)
        {
            if(MatrizSeleccionada == MatrizCriterio)
            {
                MatrizCriterioModificada(null, fila, columna, valor);
            }
            else
            {
                MatrizAlternativaModificada(_matricesAHPAlternativas.IndexOf(MatrizSeleccionada), fila, columna, valor);
            }
        }

        public void GuardarConsistencia()
        {
            if (MatrizSeleccionada == MatrizCriterio)
            {
                MatrizCriterioConsistente(null, MatrizSeleccionada.Consistente);
            }
            else
            {
                MatrizAlternativasConsistente(_matricesAHPAlternativas.IndexOf(MatrizSeleccionada), MatrizSeleccionada.Consistente);
            }
        }

        public void MatrizSeleccionadaEditada()
        {
            MatrizSeleccionada.Consistente = false;
            GuardarConsistencia();
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
