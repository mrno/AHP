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
        #region Atributos
        
        private ValorarAlternativaILViewModel _alternativaSeleccionada;

        #endregion

        #region Constructores

        public ValoracionILViewModel()
        {
            Etiquetas = new ReadOnlyCollection<string>(new List<string>() { "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Uno", "Dos", "Tres" });
            AlternativasIL =
                new ReadOnlyCollection<ValorarAlternativaILViewModel>(new List<ValorarAlternativaILViewModel>()
                                                                          {
                                                                              new ValorarAlternativaILViewModel("a1",
                                                                                                                new List
                                                                                                                    <
                                                                                                                    ValorCriterio
                                                                                                                    >()
                                                                                                                    {
                                                                                                                        new ValorCriterio
                                                                                                                            ()
                                                                                                                            {
                                                                                                                                Nombre
                                                                                                                                    =
                                                                                                                                    "C1",
                                                                                                                                ValorILNumerico
                                                                                                                                    =
                                                                                                                                    4
                                                                                                                            },
                                                                                                                             new ValorCriterio
                                                                                                                            ()
                                                                                                                            {
                                                                                                                                Nombre
                                                                                                                                    =
                                                                                                                                    "C2",
                                                                                                                                ValorILNumerico
                                                                                                                                    =
                                                                                                                                    10
                                                                                                                            },
                                                                                                                             new ValorCriterio
                                                                                                                            ()
                                                                                                                            {
                                                                                                                                Nombre
                                                                                                                                    =
                                                                                                                                    "C3",
                                                                                                                                ValorILNumerico
                                                                                                                                    =
                                                                                                                                    8
                                                                                                                            }
                                                                                                                    }, 13),
                                                                              new ValorarAlternativaILViewModel("a2",
                                                                                                                new List
                                                                                                                    <
                                                                                                                    ValorCriterio
                                                                                                                    >()
                                                                                                                    {
                                                                                                                        new ValorCriterio
                                                                                                                            ()
                                                                                                                            {
                                                                                                                                Nombre
                                                                                                                                    =
                                                                                                                                    "C2",
                                                                                                                                ValorILNumerico
                                                                                                                                    =
                                                                                                                                    1
                                                                                                                            }
                                                                                                                    }, 13),
                                                                              new ValorarAlternativaILViewModel("a3",
                                                                                                                new List
                                                                                                                    <
                                                                                                                    ValorCriterio
                                                                                                                    >()
                                                                                                                    {
                                                                                                                        new ValorCriterio
                                                                                                                            ()
                                                                                                                            {
                                                                                                                                Nombre
                                                                                                                                    =
                                                                                                                                    "C3",
                                                                                                                                ValorILNumerico
                                                                                                                                    =
                                                                                                                                    2
                                                                                                                            }
                                                                                                                    }, 13),
                                                                              new ValorarAlternativaILViewModel("a1",
                                                                                                                new List
                                                                                                                    <
                                                                                                                    ValorCriterio
                                                                                                                    >()
                                                                                                                    {
                                                                                                                        new ValorCriterio
                                                                                                                            ()
                                                                                                                            {
                                                                                                                                Nombre
                                                                                                                                    =
                                                                                                                                    "C4",
                                                                                                                                ValorILNumerico
                                                                                                                                    =
                                                                                                                                    3
                                                                                                                            }
                                                                                                                    }, 13)
                                                                          });
            AlternativaSeleccionada = AlternativasIL.Skip(1).First();
        }

        public ValoracionILViewModel(IEnumerable<Etiqueta> etiquetas, IEnumerable<AlternativaIL> alternativaILs)
        {
            Etiquetas =
                new ReadOnlyCollection<string>(
                    etiquetas.Select(x => etiquetas.ToList().IndexOf(x) + " - " + x.Nombre).ToList());
            AlternativasIL =
                new ReadOnlyCollection<ValorarAlternativaILViewModel>(
                    alternativaILs.Select(
                        x => new ValorarAlternativaILViewModel(x.Nombre, x.ValorCriterios, etiquetas.Count())).ToList());

        }

        #endregion

        #region Propiedades

        public ReadOnlyCollection<ValorarAlternativaILViewModel> AlternativasIL { get; private set; }

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

        //public RelayCommand<OperatorViewModel> AddCommand { get; set; }
        //private void OnAddOperator(OperatorViewModel selectedOperator)
        //{
        //    SelectedOperators.Add(selectedOperator);
        //    OnPropertyChanged("AvailableOperators");

        //    SelectedOperator = selectedOperator;
        //    OnPropertyChanged("SelectedOperator");
        //}

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
