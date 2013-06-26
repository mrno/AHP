using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using sisExperto;
using sisexperto.UI.WPFUserControls.ViewModels;
using sisexperto.UI.WPFUserControls.Views;
using sisexperto.Entidades.AHP;
using sisexperto.Entidades.IL;
using sisExperto.Entidades;

namespace sisexperto.UI.WPFUserControls
{
    /// <summary>
    /// Interaction logic for ValoracionControl.xaml
    /// </summary>
    public partial class ValoracionControl : UserControl
    {
        private FachadaProyectosExpertos _fachadaProyectosExpertos;

        private ValorarProyectosViewModel _valorarProyectosViewModel;
        public ValoracionControl(FachadaProyectosExpertos fachadaProyectos)
        {
            InitializeComponent();
            _fachadaProyectosExpertos = fachadaProyectos;
            _valorarProyectosViewModel = new ValorarProyectosViewModel();
            this.DataContext = _valorarProyectosViewModel;
        }

        public void CargarValoraciones(Proyecto proyecto, ValoracionAHP valoracionAHP, ValoracionIL valoracionIL)
        {
            if (valoracionAHP != null)
            {
                _valorarProyectosViewModel.ValoracionAHP = new ValoracionAHPViewModel(proyecto.Criterios,
                                                                                          valoracionAHP.CriterioMatriz,
                                                                                          proyecto.Alternativas,
                                                                                          valoracionAHP.AlternativasMatrices);
                //suscribo un método al evento de modificacion
                _valorarProyectosViewModel.ValoracionAHP.MatrizCriterioModificada +=
                    (matriz, fila, columna, valor) 
                        => _fachadaProyectosExpertos.GuardarValoracion(valoracionAHP, fila, columna,valor);

                //suscribo un método para guardar la consistencia
                _valorarProyectosViewModel.ValoracionAHP
                    .MatrizCriterioConsistente += (matriz, consistencia) => _fachadaProyectosExpertos.GuardarConsistencia
                                                                (valoracionAHP, matriz, consistencia);

                //suscribo un método al evento de la modificacion
                _valorarProyectosViewModel.ValoracionAHP.MatrizAlternativaModificada +=
                    (matriz, fila, columna, valor) 
                        => _fachadaProyectosExpertos.GuardarValoracion(valoracionAHP, matriz, fila, columna, valor);

                //suscribo un método para guardar la consistencia
                _valorarProyectosViewModel.ValoracionAHP
                    .MatrizAlternativasConsistente += (matriz, consistencia) => _fachadaProyectosExpertos.GuardarConsistencia
                                                                    (valoracionAHP, matriz, consistencia);
            }
            else
            {
                _valorarProyectosViewModel.ValoracionAHP = null;
            }

            if (valoracionIL != null)
            {
                _valorarProyectosViewModel.ValoracionIL = new ValoracionILViewModel(
                        valoracionIL.ConjuntoEtiquetas.Etiquetas, valoracionIL.AlternativasIL);

                _valorarProyectosViewModel.ValoracionIL.ValoracionDeCriterioModificada +=
                    (alternativa, criterio, valor) =>
                    _fachadaProyectosExpertos.GuardarValoracionIL(valoracionIL, alternativa, criterio, valor);
            }
            else
            {
                _valorarProyectosViewModel.ValoracionIL = null;
            }

            _valorarProyectosViewModel.MostrarAHP = valoracionAHP != null;
        }
    }
}
