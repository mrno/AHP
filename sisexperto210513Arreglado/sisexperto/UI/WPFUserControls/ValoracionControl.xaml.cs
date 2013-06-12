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
    }
}
