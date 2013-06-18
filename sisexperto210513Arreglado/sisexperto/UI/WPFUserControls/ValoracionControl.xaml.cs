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
        private ValorarProyectosViewModel _valorarProyectosViewModel;
        public ValoracionControl()
        {
            InitializeComponent();
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
            }
            else
            {
                _valorarProyectosViewModel.ValoracionAHP = null;
            }

            if (valoracionIL != null)
            {
                _valorarProyectosViewModel.ValoracionIL = new ValoracionILViewModel(
                        valoracionIL.ConjuntoEtiquetas.Etiquetas, valoracionIL.AlternativasIL); 
            }
            else
            {
                _valorarProyectosViewModel.ValoracionIL = null;
            }

            _valorarProyectosViewModel.MostrarAHP = valoracionAHP != null;
        }
    }
}
